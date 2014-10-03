using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenScraping
{
    public class HomeStepsBPOForm
    {
        #region Members

        private object _BPOData = null;

        #endregion

        #region Properties

        public Dictionary<string, string> MarketAreaData
        {
            get
            {
                return GetMarketAreaData();
            }
        }

        public Dictionary<string, string> PreviousListingData
        {
            get
            {
                return GetPreviousListingData();
            }
        }

        public Dictionary<string, string> CurrentSituationData
        {
            get
            {
                return GetCurrentSituationData();
            }
        }

        public Dictionary<string, string> PreservationMaintenanceData
        {
            get
            {
                return GetPreservationMaintenanceData();
            }
        }

        public Dictionary<string, string> ValueMarketingRecommendationsData
        {
            get
            {
                return GetValueMarketingRecommendationsData();
            }
        }

        public Dictionary<string, string> CompListingsData
        {
            get
            {
                return GetCompListingsData();
            }
        }

        public Dictionary<string, string> CompSalesData
        {
            get
            {
                return GetCompSalesData();
            }
        }

        public Dictionary<string, string> ComponentsOnCompsData
        {
            get
            {
                return GetComponentsOnCompsData();
            }
        }

        #endregion

        #region Constructors

        public HomeStepsBPOForm(object data)
        {
            _BPOData = data;
        }

        #endregion

        #region Helpers

        private Dictionary<string, string> GetMarketAreaData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data["assetIdentifierString"] = "";
            data["freddieMacLoanNumber"] = "";
            data["propertyAddress.propertyStreetAddress"] = "";
            data["propertyAddress.propertyCityAddress"] = "";
            data["propertyAddress.propertyStateAddress"] = "";
            data["propertyAddress.propertyPostalCode"] = "";
            data["orderVersion.signature.companyName"] = "";
            data["orderVersion.signature.completedByName"] = "";
            data["orderVersion.signature.phoneNumber"] = "";
            data["orderVersion.marketCondition.marketCodeString"] = "";
            data["orderVersion.marketCondition.marketValueTrendCodeString"] = "";
            data["orderVersion.marketCondition.supplyDemandCodeString"] = "";
            data["orderVersion.neighborhood.crimeLevelCodeString"] = "";
            data["orderVersion.marketCondition.quickSaleCodeString"] = "";
            data["orderVersion.marketCondition.condoCooperateCodeString"] = "";
            data["orderVersion.propertyUsageHSC[0].propertyUsagePercentString"] = "";
            data["orderVersion.propertyUsageHSC[1].propertyUsagePercentString"] = "";
            data["orderVersion.propertyUsageHSC[2].propertyUsagePercentString"] = "";
            data["orderVersion.propertyUsageHSC[3].propertyUsagePercentString"] = "";
            data["orderVersion.propertyUsageHSC[4].propertyUsagePercentString"] = "";
            data["orderVersion.propertyUsageHSC[5].propertyUsagePercentString"] = "";
            data["orderVersion.propertyUsageHSC[6].propertyUsagePercentString"] = "";
            data["orderVersion.propertyUsageHSC[7].propertyUsagePercentString"] = "";
            data["orderVersion.propertyUsageHSC[8].propertyUsagePercentString"] = "";
            data["orderVersion.propertyUsageHSC[9].propertyUsagePercentString"] = "";
            data["orderVersion.propertyUsageHSC[10].propertyUsagePercentString"] = "";
            data["orderVersion.propertyData.unitCountString"] = "";
            data["orderVersion.propertyData.floorCountString"] = "";
            data["orderVersion.propertyQualification.rentControlFlagString"] = "";
            data["orderVersion.propertyQualification.boardRegisteredCodeString"] = "";
            data["orderVersion.propertyQualification.marketRentAmountString"] = "";
            data["orderVersion.neighborhood.neighborhoodCommentText"] = "";
            data["orderVersion.propertyData.propertyTypeDescription"] = "";
            data["orderVersion.propertyData.illegalUnitsFlagString"] = "";
            data["orderVersion.valuation.taxAmountString"] = "";
            data["orderVersion.valuation.taxFullPartialCodeString"] = "";
            data["orderVersion.neighborhood.currentListingsCountString"] = "";
            data["orderVersion.neighborhood.recentSalesCountString"] = "";
            data["orderVersion.neighborhood.bankOwnedListingsCountString"] = "";
            data["orderVersion.neighborhood.lowPriceAmountString"] = "";
            data["orderVersion.neighborhood.highPriceAmountString"] = "";
            data["orderVersion.neighborhood.supplyDemandIndicator"] = "";

            return data;
        }

        private Dictionary<string, string> GetPreviousListingData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data["orderVersion.propertyQualification.previouslyListedFlagString"] = "";
            data["orderVersion.propertyData.originalListDateString"] = "";
            data["orderVersion.propertyData.originalListPriceAmountString"] = "";
            data["orderVersion.propertyData.currentListPriceAmountString"] = "";
            data["orderVersion.propertyData.propertyLocationDescription"] = "";
            data["orderVersion.propertyData.waterSourceIndicator"] = "";
            data["orderVersion.propertyData.wasteDisposalIndicator"] = "";
            data["orderVersion.propertyData.zoningCodeString"] = "";

            return data;
        }

        private Dictionary<string, string> GetCurrentSituationData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data["orderVersion.homeOwnersAssoc[0].HOASequenceNumberString"] = "";
            data["orderVersion.homeOwnersAssoc[0].HOACompanyName"] = "";
            data["orderVersion.homeOwnersAssoc[0].HOAContactName"] = "";
            data["orderVersion.homeOwnersAssoc[0].HOAPhoneNumber"] = "";
            data["orderVersion.homeOwnersAssoc[0].HOAPhoneExtensionNumber"] = "";
            data["orderVersion.homeOwnersAssoc[0].HOAFeeAmountString"] = "";
            data["orderVersion.homeOwnersAssoc[0].HOAFeeFrequencyCodeString"] = "";
            data["orderVersion.homeOwnersAssoc[0].pendingAssessmentAmountString"] = "";
            data["orderVersion.homeOwnersAssoc[0].pendingAssessmentBeginDateString"] = "";
            data["orderVersion.homeOwnersAssoc[0].pendingAssessmentEndDateString"] = "";
            data["orderVersion.homeOwnersAssoc[1].HOASequenceNumberString"] = "";
            data["orderVersion.homeOwnersAssoc[1].HOACompanyName"] = "";
            data["orderVersion.homeOwnersAssoc[1].HOAContactName"] = "";
            data["orderVersion.homeOwnersAssoc[1].HOAPhoneNumber"] = "";
            data["orderVersion.homeOwnersAssoc[1].HOAPhoneExtensionNumber"] = "";
            data["orderVersion.homeOwnersAssoc[1].HOAFeeAmountString"] = "";
            data["orderVersion.homeOwnersAssoc[1].HOAFeeFrequencyCodeString"] = "";
            data["orderVersion.homeOwnersAssoc[1].pendingAssessmentAmountString"] = "";
            data["orderVersion.homeOwnersAssoc[1].pendingAssessmentBeginDateString"] = "";
            data["orderVersion.homeOwnersAssoc[1].pendingAssessmentEndDateString"] = "";
            data["orderVersion.habitabilityQuestion[0].habitabilityAnswerCodeString"] = "";
            data["orderVersion.habitabilityQuestion[1].habitabilityAnswerCodeString"] = "";
            data["orderVersion.habitabilityQuestion[2].habitabilityAnswerCodeString"] = "";
            data["orderVersion.habitabilityQuestion[3].habitabilityAnswerCodeString"] = "";
            data["orderVersion.habitabilityQuestion[4].habitabilityAnswerCodeString"] = "";
            data["orderVersion.habitabilityQuestion[5].habitabilityAnswerCodeString"] = "";
            data["orderVersion.habitabilityQuestion[6].habitabilityAnswerCodeString"] = "";
            data["orderVersion.habitabilityQuestion[7].habitabilityAnswerCodeString"] = "";
            data["orderVersion.habitabilityQuestion[8].habitabilityAnswerCodeString"] = "";
            data["orderVersion.habitabilityQuestion[9].habitabilityAnswerCodeString"] = "";
            data["orderVersion.habitabilityQuestion[10].habitabilityAnswerCodeString"] = "";
            data["orderVersion.habitabilityQuestion[11].habitabilityAnswerCodeString"] = "";
            data["orderVersion.habitabilityQuestion[12].habitabilityAnswerCodeString"] = "";
            data["orderVersion.propertyQualification.habitabilityCommentText"] = "";
            data["orderVersion.healthQuestion[0].healthAnswerCodeString"] = "";
            data["orderVersion.healthQuestion[1].healthAnswerCodeString"] = "";
            data["orderVersion.propertyQualification.healthCommentText"] = "";
            data["orderVersion.propertyQualification.termiteInspectionFlagString"] = "";
            data["orderVersion.propertyQualification.roofInspectionFlagString"] = "";
            data["orderVersion.propertyQualification.systemInspectionFlagString"] = "";
            data["orderVersion.propertyQualification.septicInspectionFlagString"] = "";
            data["orderVersion.propertyQualification.structureInspectionFlagString"] = "";
            data["orderVersion.propertyQualification.otherInspectionFlagString"] = "";

            return data;
        }

        private Dictionary<string, string> GetPreservationMaintenanceData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data["orderVersion.preservationMaintenance[0].maintenanceAmountString"] = "";
            data["orderVersion.preservationMaintenance[1].maintenanceAmountString"] = "";
            data["orderVersion.preservationMaintenance[2].maintenanceAmountString"] = "";
            data["orderVersion.preservationMaintenance[3].maintenanceAmountString"] = "";
            data["orderVersion.preservationMaintenance[4].maintenanceAmountString"] = "";
            data["orderVersion.preservationMaintenance[5].maintenanceAmountString"] = "";
            data["orderVersion.preservationMaintenance[6].maintenanceAmountString"] = "";
            data["orderVersion.propertyImprovement[0].repairCodeString"] = "";
            data["orderVersion.propertyImprovement[0].repairAmountString"] = "";
            data["orderVersion.propertyImprovement[0].repairReplaceIndicator"] = "";
            data["orderVersion.propertyImprovement[0].wearTearIndicator"] = "";
            data["orderVersion.propertyImprovement[1].repairCodeString"] = "";
            data["orderVersion.propertyImprovement[1].repairAmountString"] = "";
            data["orderVersion.propertyImprovement[1].repairReplaceIndicator"] = "";
            data["orderVersion.propertyImprovement[1].wearTearIndicator"] = "";
            data["orderVersion.propertyImprovement[2].repairCodeString"] = "";
            data["orderVersion.propertyImprovement[2].repairAmountString"] = "";
            data["orderVersion.propertyImprovement[2].repairReplaceIndicator"] = "";
            data["orderVersion.propertyImprovement[2].wearTearIndicator"] = "";
            data["orderVersion.propertyImprovement[3].repairCodeString"] = "";
            data["orderVersion.propertyImprovement[3].repairAmountString"] = "";
            data["orderVersion.propertyImprovement[3].repairReplaceIndicator"] = "";
            data["orderVersion.propertyImprovement[3].wearTearIndicator"] = "";
            data["orderVersion.propertyImprovement[4].repairCodeString"] = "";
            data["orderVersion.propertyImprovement[4].repairAmountString"] = "";
            data["orderVersion.propertyImprovement[4].repairReplaceIndicator"] = "";
            data["orderVersion.propertyImprovement[4].wearTearIndicator"] = "";
            data["orderVersion.propertyImprovement[5].repairCodeString"] = "";
            data["orderVersion.propertyImprovement[5].repairAmountString"] = "";
            data["orderVersion.propertyImprovement[5].repairReplaceIndicator"] = "";
            data["orderVersion.propertyImprovement[5].wearTearIndicator"] = "";
            data["orderVersion.propertyImprovement[6].repairCodeString"] = "";
            data["orderVersion.propertyImprovement[6].repairAmountString"] = "";
            data["orderVersion.propertyImprovement[6].repairReplaceIndicator"] = "";
            data["orderVersion.propertyImprovement[6].wearTearIndicator"] = "";
            data["orderVersion.propertyImprovement[7].repairCodeString"] = "";
            data["orderVersion.propertyImprovement[7].repairAmountString"] = "";
            data["orderVersion.propertyImprovement[7].repairReplaceIndicator"] = "";
            data["orderVersion.propertyImprovement[7].wearTearIndicator"] = "";
            data["orderVersion.propertyImprovement[8].repairCodeString"] = "";
            data["orderVersion.propertyImprovement[8].repairAmountString"] = "";
            data["orderVersion.propertyImprovement[8].repairReplaceIndicator"] = "";
            data["orderVersion.propertyImprovement[8].wearTearIndicator"] = "";
            data["orderVersion.propertyImprovement[9].repairCodeString"] = "";
            data["orderVersion.propertyImprovement[9].repairAmountString"] = "";
            data["orderVersion.propertyImprovement[9].repairReplaceIndicator"] = "";
            data["orderVersion.propertyImprovement[9].wearTearIndicator"] = "";
            data["orderVersion.propertyImprovement[10].repairCodeString"] = "";
            data["orderVersion.propertyImprovement[10].otherTypeDescription"] = "";
            data["orderVersion.propertyImprovement[10].repairAmountString"] = "";
            data["orderVersion.propertyImprovement[10].repairReplaceIndicator"] = "";
            data["orderVersion.propertyImprovement[10].wearTearIndicator"] = "";
            data["repTotals"] = "";

            return data;
        }

        private Dictionary<string, string> GetValueMarketingRecommendationsData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data["orderVersion.valuation.suggestedListAmountString"] = "";
            data["orderVersion.valuation.suggestedRepairListAmountString"] = "";
            data["orderVersion.valuation.probable90AsIsAmountString"] = "";
            data["orderVersion.valuation.probable90RepairAmountString"] = "";
            data["orderVersion.marketCondition.currentMarketConditionText"] = "";
            data["orderVersion.valuation.sellStrategyCommentText"] = "";
            data["orderVersion.marketCondition.targetBuyerCodeString"] = "";
            data["orderVersion.marketCondition.likelyFinancingCodeString"] = "";
            data["orderVersion.signature.inspectedDateString"] = "";

            return data;
        }

        private Dictionary<string, string> GetCompListingsData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data["orderVersion.propertyData.financingConcessionDescription"] = "";
            data["orderVersion.propertyData.daysOnMarketCountString"] = "";
            data["orderVersion.propertyQualification.siteViewCodeString"] = "";
            data["orderVersion.propertyData.lotSizeValue"] = "";
            data["orderVersion.propertyData.squareFootageCountString"] = "";
            data["orderVersion.propertyData.yearBuiltDate"] = "";
            data["orderVersion.propertyData.subjectConditionCodeString"] = "";
            data["orderVersion.propertyData.roomCountCodeString"] = "";
            data["orderVersion.propertyData.bedroomCountCodeString"] = "";
            data["orderVersion.propertyData.bathroomCountCodeString"] = "";
            data["orderVersion.propertyData.basementCodeString"] = "";
            data["orderVersion.propertyData.basementDescription"] = "";
            data["orderVersion.propertyQualification.heatingCoolingCodeString"] = "";
            data["orderVersion.propertyData.coolingFlagString"] = "";
            data["orderVersion.propertyData.parkingAreaFlagString"] = "";
            data["orderVersion.propertyData.garageCodeString"] = "";
            data["orderVersion.propertyData.swimmingPoolCodeString"] = "";
            data["orderVersion.propertyData.spaFlagString"] = "";
            
            for (int i = 0; i < 3; i++)
            {
                data[string.Format("orderVersion.competitiveListings[{0}].streetAddress", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].unitCountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].HSCComparable.proximitySubjectCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].originalListPriceAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].lastListPriceAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].HSCComparable.sellerTypeCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].financingConcessionDescription", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[0].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].DOMCountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[1].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].HSCComparable.locationAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[2].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].HSCComparable.siteViewCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[3].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].lotSizeValue", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[4].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].propertyStyleDescription", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[5].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].squareFootageCountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[6].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].yearBuiltDate", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[7].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].propertyConditionCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[8].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].roomCountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[9].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].bedroomCountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[10].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].bathroomCountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[11].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].HSCComparable.basementCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].basementDescription", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[12].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].HSCComparable.heatingTypeCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[13].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].HSCComparable.coolingSystemFlagString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[14].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].HSCComparable.waterSourceIndicator", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[15].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].HSCComparable.wasteDisposalIndicator", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[16].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].HSCComparable.parkingAreaFlagString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[17].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].garageCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[18].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].HSCComparable.swimmingPoolCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[19].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].HSCComparable.spaFlagString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[20].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].specialFeatureText", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].competitiveListingsHSCValAdjA[21].valueAdjustmentAmountString", i)] = "";

                switch (i)
                {
                    case 0:
                        data["repTotalsLstgA"] = "";
                        data["currentListPrice_A"] = "";
                        data["sumOfValAdjWithoutCurrPrice_A"] = "";
                        data["repTotalsLstgA"] = "";
                        break;
                    case 1:
                        data["repTotalsLstgB"] = "";
                        data["currentListPrice_B"] = "";
                        data["sumOfValAdjWithoutCurrPrice_B"] = "";
                        data["repTotalsLstgB"] = "";
                        break;
                    case 2:
                        data["repTotalsLstgC"] = "";
                        data["currentListPrice_C"] = "";
                        data["sumOfValAdjWithoutCurrPrice_C"] = "";
                        data["repTotalsLstgC"] = "";
                        break;
                    default:
                        break;
                }
            }

            data["orderVersion.competitiveListings[0].mostComparableProperty"] = "";

            return data;
        }

        private Dictionary<string, string> GetCompSalesData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            for (int i = 0; i < 3; i++)
            {
                data[string.Format("orderVersion.comparableSales[{0}].streetAddress", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].HSCComparable.proximitySubjectCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].finalSalesPriceAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].currentSaleListDateString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].HSCComparable.sellerTypeCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].financingConcessionDescription", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[0].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].DOMCountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[1].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].HSCComparable.locationAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[2].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].HSCComparable.siteViewCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[3].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].lotSizeValue", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[4].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].propertyStyleDescription", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[5].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].squareFootageCountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[6].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].yearBuiltDate", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[7].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].propertyConditionCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[8].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].roomCountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[9].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].bedroomCountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[10].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].bathroomCountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[11].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].HSCComparable.basementCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].basementDescription", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[12].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].HSCComparable.heatingTypeCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[13].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].HSCComparable.coolingSystemFlagString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[14].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].HSCComparable.waterSourceIndicator", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[15].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].HSCComparable.wasteDisposalIndicator", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[16].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].HSCComparable.parkingAreaFlagString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[17].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].garageCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[18].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].HSCComparable.swimmingPoolCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[19].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].HSCComparable.spaFlagString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[20].valueAdjustmentAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].specialFeatureText", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].comparableSalesHSCValAdjA[21].valueAdjustmentAmountString", i)] = "";

                switch (i)
                {
                    case 0:
                        data["repSalesTotalsLstgA"] = "";
                        data["salesPrice_A"] = "";
                        data["sumOfValAdjWithoutCurrPrice_D"] = "";
                        data["repSalesTotalsLstgA"] = "";
                        break;
                    case 1:
                        data["repSalesTotalsLstgB"] = "";
                        data["salesPrice_B"] = "";
                        data["sumOfValAdjWithoutCurrPrice_E"] = "";
                        data["repSalesTotalsLstgB"] = "";
                        break;
                    case 2:
                        data["repSalesTotalsLstgC"] = "";
                        data["salesPrice_C"] = "";
                        data["sumOfValAdjWithoutCurrPrice_F"] = "";
                        data["repSalesTotalsLstgC"] = "";
                        break;
                    default:
                        break;
                }
            }

            data["orderVersion.comparableSales[0].mostComparableProperty"] = "";

            return data;
        }

        private Dictionary<string, string> GetComponentsOnCompsData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data["orderVersion.propertyData.specialFeatureText"] = "";
            data["orderVersion.propertyData.issueCommentText"] = "";
            data["orderVersion.propertyQualification.QCEditCommentText"] = "";
            data["orderVersion.comparableSales[0].HSCComparable.proximitySubjectCodeString"] = "";
            data["orderVersion.comparableSales[1].HSCComparable.proximitySubjectCodeString"] = "";
            data["orderVersion.comparableSales[2].HSCComparable.proximitySubjectCodeString"] = "";
            data["orderVersion.comparableSales[0].currentSaleListDateString"] = "";
            data["orderVersion.comparableSales[1].currentSaleListDateString"] = "";
            data["orderVersion.comparableSales[2].currentSaleListDateString"] = "";
            data["orderVersion.comparableSales[0].mostComparableProperty"] = "";
            data["orderVersion.competitiveListings[0].mostComparableProperty"] = "";
            data["orderVersion.propertyData.squareFootageCountString"] = "";
            data["orderVersion.signature.inspectedDateString"] = "";
            data["orderVersion.valuation.suggestedListAmountString"] = "";

            return data;
        }

        #endregion
    }
}
