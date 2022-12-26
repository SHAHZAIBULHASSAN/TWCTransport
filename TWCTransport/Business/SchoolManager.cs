using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using TWCTransport.Model;
using TWCTransport.Provider;

namespace TWCTransport.Business
{
    public class SchoolManager:ISchool
    {
        readonly ServiceClient client;
        readonly IDataverseProvider dataverseProvider;
        public SchoolManager(IDataverseProvider dataverseProvider)
        {
            this.dataverseProvider = dataverseProvider;
            this.client = this.dataverseProvider.GetServiceClient();
        }
        private static School MapToSchoolDataverse(Entity entity)
        {
            var result = new School();
            result.Id = entity.GetAttributeValue<Guid>("ss_schoolid");
            result.SchoolPostCode = entity.GetAttributeValue<string>("ss_postcode");
            result.SchoolAnalysisCode = entity.GetAttributeValue<string>("ss_analysiscode");
            result.SchoolNumber = entity.GetAttributeValue<int>("ss_schoolnumber");
            result.SchoolName = entity.GetAttributeValue<string>("ss_name");
            result.SchoolName = entity.GetAttributeValue<string>("ss_educationtype");
            return result;
        }
    
      

     
//        public async Task<School> CreateSchoolAsync(School schooldata)
//        {

//            var entity = new Entity("ss_school");
//            // var bookAuthorLookup = entity.GetAttributeValue<EntityReference>("mgt_author");
//            entity["ss_contacttitle"] = trnsReqModelData.ContactTitle;

////            < fetch >
////  < entity name = "ss_school" >
////    < attribute name = "ss_schoolid" />
////    < attribute name = "ss_postcode" />
////    < attribute name = "ss_name" />
////    < attribute name = "ss_analysiscode" />
////    < attribute name = "ss_educationtype" />
////    < attribute name = "ss_schoolnumber" />
////  </ entity >
////</ fetch >



//            entity["ss_sendormedicaldetails"] = trnsReqModelData.SendOrMedicalDetails;
//            entity["ss_sendormedicalhassendormedicalneeds"] = trnsReqModelData.SendOrMedicalHasSendOrMedicalNeeds;
//            entity["ss_studentdetailsaddressline1"] = trnsReqModelData.StudentDetailsAddressLine1;
//            entity["ss_studentdetailsaddressline2"] = trnsReqModelData.StudentDetailsAddressLine2;
//            entity["ss_studentdetailsaddressline3"] = trnsReqModelData.StudentDetailsAddressLine3;
//            entity["ss_studentdetailsaddressline4"] = trnsReqModelData.StudentDetailsAddressLine4;
//            entity["ss_studentdetailsaddresspostcode"] = trnsReqModelData.StudentDetailsAddressPostcode;
//            entity["ss_studentdetailshasdisabilitylivingallowance"] = trnsReqModelData.StudentDetailsHasDisabilityLivingAllowance;
//            entity["ss_studentdetailsincare"] = trnsReqModelData.StudentDetailsInCare;
//            entity["ss_studentdetailslivesatdifferentaddress"] = trnsReqModelData.StudentDetailsLivesAtDifferentAddress;
//            entity["ss_studentdetailssocialworker"] = trnsReqModelData.StudentDetailsSocialWorker;
//            entity["ss_supportcalming"] = trnsReqModelData.SupportCalming;





//            entity["ss_supportother"] = trnsReqModelData.SupportOther;
//            entity["timezoneruleversionnumber"] = trnsReqModelData.TimeZoneRuleVersionNumber;
//            entity["ss_transportharnessrequired"] = trnsReqModelData.TransportHarnessRequired;
//            entity["ss_transporthasownvehicle"] = trnsReqModelData.TransportHasOwnVehicle;
//            entity["ss_transportnosharedtransportdetails"] = trnsReqModelData.TransportNoSharedTransportDetails;
//            entity["ss_transportremoveseatbelt"] = trnsReqModelData.TransportRemoveSeatBelt;
//            entity["ss_transportrequestnumber"] = trnsReqModelData.TransportRequestNumber;
//            entity["ss_transportroadsafety"] = trnsReqModelData.TransportRoadSafety;
//            entity["ss_transportseatdetails"] = trnsReqModelData.TransportSeatDetails;
//            entity["ss_transportstartdate"] = trnsReqModelData.TransportStartDate;
//            entity["ss_transportstudentjourneydetails"] = trnsReqModelData.TransportStudentJourneyDetails;
//            entity["ss_transporttraveltraining"] = trnsReqModelData.TransportTravelTraining;
//            entity["ss_transportwhynotfamilyorfriends"] = trnsReqModelData.TransportWhyNotFamilyOrFriends;
//            entity["ss_transport_hastransportmedication"] = trnsReqModelData.Transport_HasTransportMedication;
//            entity["ss_transport_medicationdetails"] = trnsReqModelData.Transport_MedicationDetails;
//            entity["utcconversiontimezonecode"] = trnsReqModelData.UTCConversionTimeZoneCode;
//            entity["versionnumber"] = trnsReqModelData.VersionNumber;

//            trnsReqModelData.Id = await client.CreateAsync(entity);
//            return trnsReqModelData;
//        }

       

//        public async Task DeleteSchoolAsync(Guid id)
//        {
//            await client.DeleteSchoolAsync("ss_school", id);
//        }

//        public async Task<School> GetSchoolByIdAsync(Guid id)
//        {
//            var entity = await client.RetrieveAsync("ss_school", id, new ColumnSet(true));
//            var record = MapToSchoolDataverse(entity);

//            return record;
//        }

        public string GetSchoolListAsync()
        {
            return "API Response";
            var query = new QueryExpression
            {
                EntityName = "ss_school",
                ColumnSet = new ColumnSet(true),

            };
            List<School> listSchools = null;

            EntityCollection entityCollection = client.RetrieveMultiple(query);
            try
            {
                if (entityCollection.Entities != null && entityCollection != null && entityCollection.Entities.Count > 0)
                {
                    var list = entityCollection.Entities;
                    School schools = new School();
                   // new List<School>();
                    
                    foreach( var school in entityCollection.Entities)
                    {
                        listSchools = new List<School>();
                        var schoolObj = school;
                     //   schools.SchoolName = schoolObj;
                         listSchools = entityCollection.Entities.Select(entity => MapToSchoolDataverse(entity)).ToList();
                       // return list;
                        
                       
                    }
                }
                

               
            }
            catch (Exception)
            {

                throw;
            }
           // return listSchools;
        }

        async Task<List<School>> ISchool.GetSchoolListAsync()
        {
            var query = new QueryExpression
            {
                EntityName = "ss_transportrequest",
                ColumnSet = new ColumnSet(true),

            };

            var entityCollection = await client.RetrieveMultipleAsync(query);
            var list = entityCollection.Entities.Select(entity => MapToSchoolDataverse(entity)).ToList();
            return list;
        }

        //public async Task UpdateSchoolAsync(School schooldata)
        //{
        //    Entity lookupvalue = new Entity("ss_transportrequest");

        //    lookupvalue["ss_transportrequestid"] = trnsReqModelData.Id;

        //    lookupvalue["ss_contactfirstname"] = trnsReqModelData.ContactFirstName;
        //    lookupvalue["ss_contactlastname"] = trnsReqModelData.ContactLastName;
        //    lookupvalue["ss_contactemail"] = trnsReqModelData.ContactEmail;
        //    lookupvalue["ss_contactphone"] = trnsReqModelData.ContactPhone;
        //    lookupvalue["ss_contactaddressline1"] = trnsReqModelData.ContactAddressline1;
        //    lookupvalue["ss_contactaddressline2"] = trnsReqModelData.ContactAddressline2;
        //    lookupvalue["ss_contactaddressline3"] = trnsReqModelData.ContactAddressline3;
        //    lookupvalue["ss_contactaddressline4"] = trnsReqModelData.ContactAddressline4;
        //    lookupvalue["ss_contactaddresspostcode"] = trnsReqModelData.ContactAddressPostcode;
        //    lookupvalue["ss_contactrelationship"] = trnsReqModelData.ContactRelationship;

        //    lookupvalue["ss_contactrelationship"] = trnsReqModelData.CreatedOn;
        //    lookupvalue["ss_documentviewercontrol"] = trnsReqModelData.DocumentViewerControl;
        //    lookupvalue["ss_educationcoursetitle"] = trnsReqModelData.EducationCourseTitle;
        //    lookupvalue["ss_educationehcpfinaliseddate"] = trnsReqModelData.EducationEHCPFinalisedDate;
        //    lookupvalue["ss_educationfirstyearofstudy"] = trnsReqModelData.EducationFirstYearOfStudy;
        //    lookupvalue["ss_educationhasappliedforbursary"] = trnsReqModelData.EducationHasAppliedForBursary;
        //    lookupvalue["ss_educationnearestschoolcollege"] = trnsReqModelData.EducationNearestSchoolCollege;
        //    lookupvalue["ss_educationqualification"] = trnsReqModelData.EducationQualification;
        //    lookupvalue["ss_educationschooladmittancedate"] = trnsReqModelData.EducationSchoolAdmittanceDate;
        //    lookupvalue["ss_educationwhynotnearestschool"] = trnsReqModelData.EducationWhyNotNearestSchool;

        //    //lookup
        //    lookupvalue.Attributes["createdby"] = new EntityReference("createdby", new Guid(trnsReqModelData.CreatedBy));
        //    lookupvalue.Attributes["modifiedby"] = new EntityReference("modifiedby", new Guid(trnsReqModelData.ModifiedBy));
        //    lookupvalue.Attributes["owningbusinessunit"] = new EntityReference("owningbusinessunit", new Guid(trnsReqModelData.OwningBusinessUnit));
        //    lookupvalue.Attributes["owningteam"] = new EntityReference("owningteam", new Guid(trnsReqModelData.OwningTeam));
        //    lookupvalue.Attributes["owninguser"] = new EntityReference("owninguser", new Guid(trnsReqModelData.OwningUser));


        //    lookupvalue["importsequencenumber"] = trnsReqModelData.ImportSequenceNumber;
        //    lookupvalue["ss_maximumtaxcredits"] = trnsReqModelData.MaximumTaxCredits;
        //    lookupvalue["ss_mobilitycantransfertoseatwhilsttravelling"] = trnsReqModelData.MobilityCanTransferToSeatWhilstTravelling;
        //    lookupvalue["ss_mobilitydetails"] = trnsReqModelData.MobilityDetails;
        //    lookupvalue["ss_mobilityequipmentdimensions"] = trnsReqModelData.MobilityEquipmentDimensions;
        //    lookupvalue["ss_mobilityhasissues"] = trnsReqModelData.MobilityHasIssues;
        //    lookupvalue["modifiedon"] = trnsReqModelData.ModifiedOn;
        //    lookupvalue["ss_otherdetails"] = trnsReqModelData.OtherDetails;
        //    lookupvalue["overriddencreatedon"] = trnsReqModelData.OverriddenCreatedOn;

        //    lookupvalue["ss_seizuresfrequency"] = trnsReqModelData.SeizuresFrequency;
        //    lookupvalue["ss_seizureshasseizures"] = trnsReqModelData.SeizuresHasSeizures;
        //    lookupvalue["ss_seizuressigns"] = trnsReqModelData.SeizuresSigns;
        //    lookupvalue["ss_seizurestype"] = trnsReqModelData.SeizuresType;
        //    lookupvalue["ss_sendormedicaldetails"] = trnsReqModelData.SendOrMedicalDetails;
        //    lookupvalue["ss_sendormedicalhassendormedicalneeds"] = trnsReqModelData.SendOrMedicalHasSendOrMedicalNeeds;
        //    lookupvalue["ss_studentdetailsaddressline1"] = trnsReqModelData.StudentDetailsAddressLine1;
        //    lookupvalue["ss_studentdetailsaddressline2"] = trnsReqModelData.StudentDetailsAddressLine2;
        //    lookupvalue["ss_studentdetailsaddressline3"] = trnsReqModelData.StudentDetailsAddressLine3;
        //    lookupvalue["ss_studentdetailsaddressline4"] = trnsReqModelData.StudentDetailsAddressLine4;
        //    lookupvalue["ss_studentdetailsaddresspostcode"] = trnsReqModelData.StudentDetailsAddressPostcode;
        //    lookupvalue["ss_studentdetailshasdisabilitylivingallowance"] = trnsReqModelData.StudentDetailsHasDisabilityLivingAllowance;
        //    lookupvalue["ss_studentdetailsincare"] = trnsReqModelData.StudentDetailsInCare;
        //    lookupvalue["ss_studentdetailslivesatdifferentaddress"] = trnsReqModelData.StudentDetailsLivesAtDifferentAddress;
        //    lookupvalue["ss_studentdetailssocialworker"] = trnsReqModelData.StudentDetailsSocialWorker;
        //    lookupvalue["ss_supportcalming"] = trnsReqModelData.SupportCalming;

        //    lookupvalue["ss_supportother"] = trnsReqModelData.SupportOther;
        //    lookupvalue["timezoneruleversionnumber"] = trnsReqModelData.TimeZoneRuleVersionNumber;
        //    lookupvalue["ss_transportharnessrequired"] = trnsReqModelData.TransportHarnessRequired;
        //    lookupvalue["ss_transporthasownvehicle"] = trnsReqModelData.TransportHasOwnVehicle;
        //    lookupvalue["ss_transportnosharedtransportdetails"] = trnsReqModelData.TransportNoSharedTransportDetails;
        //    lookupvalue["ss_transportremoveseatbelt"] = trnsReqModelData.TransportRemoveSeatBelt;
        //    lookupvalue["ss_transportrequestnumber"] = trnsReqModelData.TransportRequestNumber;
        //    lookupvalue["ss_transportroadsafety"] = trnsReqModelData.TransportRoadSafety;
        //    lookupvalue["ss_transportseatdetails"] = trnsReqModelData.TransportSeatDetails;
        //    lookupvalue["ss_transportstartdate"] = trnsReqModelData.TransportStartDate;
        //    lookupvalue["ss_transportstudentjourneydetails"] = trnsReqModelData.TransportStudentJourneyDetails;
        //    lookupvalue["ss_transporttraveltraining"] = trnsReqModelData.TransportTravelTraining;
        //    lookupvalue["ss_transportwhynotfamilyorfriends"] = trnsReqModelData.TransportWhyNotFamilyOrFriends;
        //    lookupvalue["ss_transport_hastransportmedication"] = trnsReqModelData.Transport_HasTransportMedication;
        //    lookupvalue["ss_transport_medicationdetails"] = trnsReqModelData.Transport_MedicationDetails;
        //    lookupvalue["utcconversiontimezonecode"] = trnsReqModelData.UTCConversionTimeZoneCode;
        //    lookupvalue["versionnumber"] = trnsReqModelData.VersionNumber;

        //    try
        //    {

        //        await client.UpdateAsync(lookupvalue);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}




    }
}
