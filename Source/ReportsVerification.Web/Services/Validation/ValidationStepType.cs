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
        
    }
}