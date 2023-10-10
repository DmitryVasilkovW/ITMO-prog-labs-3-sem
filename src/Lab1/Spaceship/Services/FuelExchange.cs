namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class FuelExchange : IFuelExchange
{
    private int _otherTaxes;
    private int _excises;
    private int _processingAndDelivery;
    private int _oilCompanyIncome;
    private int _gasStationRevenues;
    private int _mineralExtractionTax;
    private int _costOfGravitonMatterProduction;
    private int _costOfProductionOfActivePlasma;

    public FuelExchange(int otherTaxes, int excises, int processingAndDelivery, int oilCompanyIncome, int gasStationRevenues, int mineralExtractionTax, int costOfGravitonMatterProduction, int costOfProductionOfActivePlasma)
    {
        _otherTaxes = otherTaxes;
        _excises = excises;
        _processingAndDelivery = processingAndDelivery;
        _oilCompanyIncome = oilCompanyIncome;
        _gasStationRevenues = gasStationRevenues;
        _mineralExtractionTax = mineralExtractionTax;
        _costOfGravitonMatterProduction = costOfGravitonMatterProduction;
        _costOfProductionOfActivePlasma = costOfProductionOfActivePlasma;

        ActivePlasmaCosting();
        GravitonMatterValueCalculations();
    }

    public int ActivePlasmaPrice { get; private set; }
    public int GravitonMatterPrice { get; private set; }

    public void ActivePlasmaCosting()
    {
        ActivePlasmaPrice = _otherTaxes + _excises + _processingAndDelivery + _oilCompanyIncome + _gasStationRevenues + _mineralExtractionTax + _costOfProductionOfActivePlasma;
    }

    public void GravitonMatterValueCalculations()
    {
        GravitonMatterPrice = _otherTaxes + _excises + _processingAndDelivery + _oilCompanyIncome + _gasStationRevenues + _mineralExtractionTax + _costOfGravitonMatterProduction;
    }
}