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

    private int _activePlasmaPrice;
    private int _gravitonMatterPrice;

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

    public int ActivePlasmaPrice
    {
        get { return _activePlasmaPrice; }
    }

    public int GravitonMatterPrice
    {
        get { return _gravitonMatterPrice; }
    }

    public void ActivePlasmaCosting()
    {
        _activePlasmaPrice = _otherTaxes + _excises + _processingAndDelivery + _oilCompanyIncome + _gasStationRevenues + _mineralExtractionTax + _costOfProductionOfActivePlasma;
    }

    public void GravitonMatterValueCalculations()
    {
        _gravitonMatterPrice = _otherTaxes + _excises + _processingAndDelivery + _oilCompanyIncome + _gasStationRevenues + _mineralExtractionTax + _costOfGravitonMatterProduction;
    }
}