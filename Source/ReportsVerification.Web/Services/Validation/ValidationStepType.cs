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

        DirectCosts1Validator,
        DirectCosts2Validator,
        DirectCosts3Validator,
        Loss1Validator,
        Loss2Validator,
        Loss3Validator,
        RevenuesNds1Validator,
        RevenuesNds2Validator,
        RevenuesNds3Validator,
        
        //Primary

        ReportsIsUniqueValidator,
        ReportsByYearValidator,
        ReportsByInnValidator,

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
        CalculationContributions3WithNdfl6BaseValidator
    }
}