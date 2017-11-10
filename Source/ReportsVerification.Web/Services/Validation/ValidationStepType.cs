namespace ReportsVerification.Web.Services.Validation
{
    public enum ValidationStepType
    {
        //Nds

        Nds1VosmechenieValidator,
        Nds1DeductionValidator,
        Nds2VosmechenieValidator,
        Nds2DeductionValidator,
        Nds3VosmechenieValidator,
        Nds3DeductionValidator,

        //DeclarationOnIncomeTax

        DeclarationOnIncomeTaxDirectCosts1Validator,
        DeclarationOnIncomeTaxDirectCosts2Validator,
        DeclarationOnIncomeTaxDirectCosts3Validator,
        DeclarationOnIncomeTaxLoss1Validator,
        DeclarationOnIncomeTaxLoss2Validator,
        DeclarationOnIncomeTaxLoss3Validator,
        DeclarationOnIncomeTaxRevenuesNds1Validator,
        DeclarationOnIncomeTaxRevenuesNds2Validator,
        DeclarationOnIncomeTaxRevenuesNds3Validator,
        
        //Primary

        PrimaryReportsIsUniqueValidator,
        PrimaryReportsByYearValidator,
        PrimaryReportsByInnValidator,

        //НДФЛ6

        Ndfl61WageMrotValidator,
        Ndfl62WageMrotValidator,
        Ndfl63WageMrotValidator,
        Ndfl64WageMrotValidator,
        Ndfl64TaxesValidator,
        Ndfl63TaxesValidator,
        Ndfl62TaxesValidator,
        Ndfl61TaxesValidator,

        //Расчет по взносам

        CalculationContributions1WithNdfl6BaseValidator,
        CalculationContributions4WithNdfl6BaseValidator,
        CalculationContributions2WithNdfl6BaseValidator,
        CalculationContributions3WithNdfl6BaseValidator,
        CalculationContributionsFirst11ErrorsValidator,
        CalculationContributionsFirst12ErrorsValidator,
        CalculationContributionsFirst13ErrorsValidator,
        CalculationContributionsFirst21ErrorsValidator,
        CalculationContributionsFirst22ErrorsValidator,
        CalculationContributionsFirst23ErrorsValidator,
        CalculationContributionsFirst31ErrorsValidator,
        CalculationContributionsFirst32ErrorsValidator,
        CalculationContributionsFirst33ErrorsValidator,
        CalculationContributionsSecondErrors11Validator,
        CalculationContributionsSecondErrors12Validator,
        CalculationContributionsSecondErrors13Validator,
        CalculationContributionsSecondErrors21Validator,
        CalculationContributionsSecondErrors22Validator,
        CalculationContributionsSecondErrors23Validator,
        CalculationContributionsSecondErrors31Validator,
        CalculationContributionsSecondErrors32Validator,
        CalculationContributionsSecondErrors33Validator,

        CalculationContributionsVsSzvm11Validator,
        CalculationContributionsVsSzvm12Validator,
        CalculationContributionsVsSzvm13Validator,
        CalculationContributionsVsSzvm24Validator,
        CalculationContributionsVsSzvm25Validator,
        CalculationContributionsVsSzvm26Validator,
        CalculationContributionsVsSzvm37Validator,
        CalculationContributionsVsSzvm38Validator,
        CalculationContributionsVsSzvm39Validator
    }
}