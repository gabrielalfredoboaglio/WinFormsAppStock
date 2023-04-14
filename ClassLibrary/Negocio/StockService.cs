using CodigoComun.Models;
using CodigoComun.Repository;

public class StockService
{
    private readonly StockRepository _stockRepository;

    public StockService(StockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public int AgregarStock(Stock stockAAgregar)
    {
        return _stockRepository.AddStock(stockAAgregar);
    }

    public Stock ObtenerStockPorId(int stockId)
    {
        return _stockRepository.GetStockPorId(stockId);
    }

    public List<Stock> ObtenerTodosLosStocks()
    {
        return _stockRepository.ObtenerTodosLosStocks();
    }


    public string EliminarStock(int idStockEliminar)
    {
        int resultado = _stockRepository.EliminarStock(idStockEliminar);

        if (resultado == 1)
        {
            return "Stock eliminado correctamente";
        }
        else if (resultado == 0)
        {
            return "No se encontró el stock a eliminar";
        }
        else
        {
            return "Error al eliminar el stock";
        }
    }
    public string ActualizarStock(Stock stockAModificar)
{
    StockRepository stockRepository = new StockRepository();
    int resultado = stockRepository.ActualizarStock(stockAModificar);

    if (resultado == 1)
    {
        return "Stock actualizado correctamente";
    }
    else
    {
        return "Error al actualizar el stock";
    }


}

}
