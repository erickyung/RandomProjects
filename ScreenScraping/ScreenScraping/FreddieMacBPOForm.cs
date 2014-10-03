using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenScraping
{
    public class FreddieMacBPOForm
    {
        #region Members

        private object _BPOData = null;

        #endregion

        #region Properties

        public Dictionary<string, string> PropertyData
        {
            get
            {
                return GetPropertyData();
            }
        }

        public Dictionary<string, string> RepairData
        {
            get
            {
                return GetRepairData();
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

        public Dictionary<string, string> ValuationData
        {
            get
            {
                return GetValuationData();
            }
        }

        #endregion

        #region Constructors

        public FreddieMacBPOForm(object data)
        {
            _BPOData = data;
        }

        #endregion

        #region Helpers

        private Dictionary<string, string> GetPropertyData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data["sellerServicerLoanNumber"] = "";
            data["orderVersion.signature.inspectionExternalFlagString"] = "";
            data["orderVersion.signature.inspectionInternalFlagString"] = "";
            data["orderVersion.signature.inspectionDeniedFlagString"] = "";
            data["orderVersion.signature.reasonText"] = "";
            data["orderVersion.signature.inspectedDateString"] = "";
            data["orderVersion.signature.companyName"] = "";
            data["orderVersion.signature.completedByName"] = "";
            data["orderVersion.signature.phoneNumber"] = "";
            data["orderVersion.propertyData.HOAFeeAmountString"] = "";
            data["orderVersion.propertyData.propertyTypeCodeString"] = "";
            data["orderVersion.propertyQualification.occupiedByCodeString"] = "";
            data["orderVersion.propertyQualification.currentlyListedFlagString"] = "";
            data["orderVersion.propertyData.listingBrokerName"] = "";
            data["orderVersion.propertyData.listingBrokerPhoneNumber"] = "";
            data["orderVersion.propertyData.currentListPriceAmountString"] = "";
            data["orderVersion.propertyData.currentListDateString"] = "";
            data["orderVersion.propertyData.originalListPriceAmountString"] = "";
            data["orderVersion.propertyData.originalListDateString"] = "";
            data["orderVersion.propertyData.roomCountCodeString"] = "";
            data["orderVersion.propertyData.bedroomCountCodeString"] = "";
            data["orderVersion.propertyData.bathroomCountCodeString"] = "";
            data["orderVersion.propertyData.squareFootageCountString"] = "";
            data["orderVersion.propertyData.propertyLocationDescription"] = "";
            data["orderVersion.propertyData.lotSizeValue"] = "";
            data["orderVersion.propertyData.propertyStyleDescription"] = "";
            data["orderVersion.propertyData.propertyAgeYearsCountString"] = "";
            data["orderVersion.propertyData.garageCodeString"] = "";
            data["orderVersion.propertyData.porchPatioDescription"] = "";
            data["orderVersion.propertyQualification.landscapeConditionCodeString"] = "";

            return data;
        }

        private Dictionary<string, string> GetRepairData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data["orderVersion.repairEstimate.interiorPaintAmountString"] = "";
            data["orderVersion.repairEstimate.interiorStructureAmountString"] = "";
            data["orderVersion.repairEstimate.interiorApplianceAmountString"] = "";
            data["orderVersion.repairEstimate.interiorUtilityAmountString"] = "";
            data["orderVersion.repairEstimate.interiorFloorAmountString"] = "";
            data["orderVersion.repairEstimate.interiorOtherAmountString"] = "";
            data["orderVersion.repairEstimate.cleaningAmountString"] = "";
            data["orderVersion.repairEstimate.exteriorPaintAmountString"] = "";
            data["orderVersion.repairEstimate.exteriorStructureAmountString"] = "";
            data["orderVersion.repairEstimate.exteriorLandscapeAmountString"] = "";
            data["orderVersion.repairEstimate.exteriorRoofAmountString"] = "";
            data["orderVersion.repairEstimate.exteriorWindowAmountString"] = "";
            data["orderVersion.repairEstimate.exteriorOtherAmountString"] = "";
            data["repTotals"] = "";
            data["orderVersion.repairEstimate.repairNeededFlagString"] = "";
            data["orderVersion.propertyData.subjectConditionCodeString"] = "";
            data["orderVersion.propertyQualification.attentionItemFlagString"] = "";
            data["orderVersion.propertyQualification.titleLegalFlagString"] = "";
            data["orderVersion.propertyQualification.environmentIssueFlagString"] = "";
            data["orderVersion.propertyData.issueCommentText"] = "";
            data["orderVersion.marketCondition.propertyValueTrendCodeString"] = "";
            data["orderVersion.propertyQualification.primaryOccupancyText"] = "";
            data["orderVersion.marketCondition.averageMarketTimeCodeString"] = "";
            data["orderVersion.neighborhood.vacancyRateCodeString"] = "";
            data["orderVersion.neighborhood.currentListingsCountString"] = "";
            data["orderVersion.neighborhood.lowPriceAmountString"] = "";
            data["orderVersion.neighborhood.highPriceAmountString"] = "";
            data["orderVersion.neighborhood.neighborhoodCommentText"] = "";

            return data;
        }

        private Dictionary<string, string> GetCompListingsData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            for (int i = 0; i < 3; i++)
            {
                data[string.Format("orderVersion.competitiveListings[{0}].streetAddress", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].proximityCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].originalListPriceAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].originalListDateString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].lastListPriceAmountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].currentSaleListDateString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].propertyLocationDescription", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].freddieMacAdjustment.locationAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].lotSizeValue", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].freddieMacAdjustment.lotSizeAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].propertyStyleDescription", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].freddieMacAdjustment.designAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].propertyAgeYearsCountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].freddieMacAdjustment.ageAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].propertyConditionCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].freddieMacAdjustment.conditionAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].roomCountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].bedroomCountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].bathroomCountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].squareFootageCountString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].garageCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].freddieMacAdjustment.garageAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].porchPatioDescription", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].freddieMacAdjustment.porchAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].overallRatingDescription", i)] = "";
                data[string.Format("orderVersion.competitiveListings[{0}].freddieMacAdjustment.overallRatingCodeString", i)] = "";
            }

            data["orderVersion.competitiveListings[0].mostComparableProperty"] = "";
            data["orderVersion.competitiveListings[0].mostComparableText"] = "";

            return data;
        }

        private Dictionary<string, string> GetCompSalesData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            for (int i = 0; i < 3; i++)
            {
                data[string.Format("orderVersion.comparableSales[{0}].streetAddress", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].proximityCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].originalListPriceAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].lastListPriceAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].finalSalesPriceAmountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].currentSaleListDateString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].DOMCountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].financingConcessionDescription", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].freddieMacAdjustment.concessionAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].propertyLocationDescription", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].freddieMacAdjustment.locationAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].lotSizeValue", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].freddieMacAdjustment.lotSizeAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].propertyStyleDescription", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].freddieMacAdjustment.designAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].propertyAgeYearsCountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].freddieMacAdjustment.ageAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].propertyConditionCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].freddieMacAdjustment.conditionAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].roomCountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].bedroomCountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].bathroomCountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].squareFootageCountString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].garageCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].freddieMacAdjustment.garageAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].porchPatioDescription", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].freddieMacAdjustment.porchAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].landscapeConditionCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].freddieMacAdjustment.landscapeAdjustmentCodeString", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].overallRatingDescription", i)] = "";
                data[string.Format("orderVersion.comparableSales[{0}].freddieMacAdjustment.overallRatingCodeString", i)] = "";
            }

            data["orderVersion.comparableSales[0].mostComparableProperty"] = "";
            data["orderVersion.comparableSales[0].mostComparableText"] = "";

            return data;
        }

        private Dictionary<string, string> GetValuationData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data["orderVersion.comparableSales[0].proximityCodeString"] = "";
            data["orderVersion.comparableSales[1].proximityCodeString"] = "";
            data["orderVersion.comparableSales[2].proximityCodeString"] = "";
            data["orderVersion.comparableSales[0].currentSaleListDateString"] = "";
            data["orderVersion.comparableSales[1].currentSaleListDateString"] = "";
            data["orderVersion.comparableSales[2].currentSaleListDateString"] = "";
            data["orderVersion.comparableSales[0].mostComparableProperty"] = "";
            data["orderVersion.competitiveListings[0].mostComparableProperty"] = "";
            data["orderVersion.propertyData.squareFootageCountString"] = "";
            data["orderVersion.signature.inspectedDateString"] = "";
            data["orderVersion.valuation.likelySaleAmountString"] = "";
            data["orderVersion.valuation.probable90AsIsAmountString"] = "";
            data["orderVersion.valuation.probable90RepairAmountString"] = "";
            data["orderVersion.valuation.probable120AsIsAmountString"] = "";
            data["orderVersion.valuation.probable120RepairAmountString"] = "";
            data["orderVersion.valuation.probable180AsIsAmountString"] = "";
            data["orderVersion.valuation.probable180RepairAmountString"] = "";
            data["orderVersion.valuation.strategyRecommendedCodeString"] = "";
            data["orderVersion.marketCondition.sellerPaidFinancingDescription"] = "";
            data["orderVersion.valuation.marketValueCommentText"] = "";
            data["orderVersion.signature.inspectedByName"] = "";
            data["orderVersion.signature.completedDateString"] = "";
            data["orderVersion.propertyQualification.QCEditCommentText"] = "";

            return data;
        }

        #endregion
    }
}
