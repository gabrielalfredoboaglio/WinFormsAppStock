using CodigoComun.Modelos.DTO;
using CodigoComun.Models;
using CodigoComun.Repository;

public class StockService
{
    private readonly StockRepository _stockRepository;

    public StockService(StockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public StockDTO AgregarStock(StockDTO stockDTOAAgregar)
    {
        try
        {
            var stock = stockDTOAAgregar.GetStock(stockDTOAAgregar);

            // Verificar si ya existe el stock
            var stockExistente = _stockRepository.ObtenerTodosLosStocks();
            if (stockExistente != null)
            {
                return new StockDTO { Mensaje = "Ya existe un stock con este artículo y depósito" };
            }

            int r = _stockRepository.AddStock(stock);

            if (r == 1)
            {
                stockDTOAAgregar.Mensaje = "Stock Agregado";
                return stockDTOAAgregar;
            }
            else
            {
                stockDTOAAgregar.HuboError = true;
                stockDTOAAgregar.Mensaje = "No se pudo agregar el Stock";
                return stockDTOAAgregar;
            }

        }
        catch (Exception ex)
        {
            stockDTOAAgregar.HuboError = true;
            stockDTOAAgregar.Mensaje = $"Ocurrio una excepcion agregando stock  {ex.Message}";
            return stockDTOAAgregar;
        }
    }

    public StockDTO ActualizarStock(StockDTO stockAActualizar)
    {
        try
        {
            Stock stock = stockAActualizar.GetStock(stockAActualizar);
            StockRepository stockRepository = new StockRepository();
            int resultado = stockRepository.ActualizarStock(stock);

            if (resultado == 1)
            {
                stockAActualizar.Mensaje = "Stock actualizado correctamente";
                return stockAActualizar;
            }
            else
            {
                stockAActualizar.HuboError = true;
                stockAActualizar.Mensaje = "Error al actualizar el stock";
                return stockAActualizar;
            }
        }
        catch (Exception ex)
        {
            stockAActualizar.HuboError = true;
            stockAActualizar.Mensaje = $"Hubo una excepcion actualizando el stock: {ex.Message}";
            return stockAActualizar;
        }
    }
    public StockDTO EliminarStock(int idStockEliminar)
    {
        try
        {
            int resultado = _stockRepository.EliminarStock(idStockEliminar);

            if (resultado == 1)
            {
                return new StockDTO { Mensaje = "Stock eliminado correctamente" };
            }
            else if (resultado == 0)
            {
                return new StockDTO { Mensaje = "No se encontró el stock a eliminar" };
            }
            else
            {
                return new StockDTO { Mensaje = "Error al eliminar el stock" };
            }
        }
        catch (Exception ex)
        {
            return new StockDTO { HuboError = true, Mensaje = $"Hubo una excepción eliminando el stock: {ex.Message}" };
        }
    }

    public StockDTO ObtenerStockPorId(int stockId)
    {
        StockRepository stockRepository = new StockRepository();
        Stock stock = stockRepository.GetStockPorId(stockId);

        if (stock != null)
        {
            return new StockDTO
            {
                Id = stock.Id,
                IdArticulo = stock.IdArticulo,
                IdDeposito = stock.IdDeposito,
                Cantidad = stock.Cantidad
            };
        }
        else
        {
            return null;
        }
    }

    public List<StockDTO> ObtenerTodosLosStocks()
    {
        var stocks = _stockRepository.ObtenerTodosLosStocks();
        var stocksDTO = new List<StockDTO>();

        foreach (var stock in stocks)
        {
            stocksDTO.Add(new StockDTO
            {
                Id = stock.Id,
                IdArticulo = stock.IdArticulo,
                IdDeposito = stock.IdDeposito,
                Cantidad = stock.Cantidad
            });
        }

        return stocksDTO;
    }


    public List<StockDTO> ObtenerStockPorDeposito(int idDeposito)
    {
        var stocks = _stockRepository.ObtenerTodosLosStocksPorDeposito(idDeposito);
        var stocksDTO = new List<StockDTO>();

        foreach (var stock in stocks)
        {
            stocksDTO.Add(new StockDTO
            {
                Id = stock.Id,
                IdArticulo = stock.IdArticulo,
                IdDeposito = stock.IdDeposito,
                Cantidad = stock.Cantidad
                
            });
        }

        return stocksDTO;
    }

    public List<StockDTO> ObtenerStockPorArticulo(int idArticulo)
    {
        var stocks = _stockRepository.ObtenerTodosLosStocksPorArticulo(idArticulo);
        var stocksDTO = new List<StockDTO>();

        foreach (var stock in stocks)
        {
            stocksDTO.Add(new StockDTO
            {
                Id = stock.Id,
                IdArticulo = stock.IdArticulo,
                IdDeposito = stock.IdDeposito,
                Cantidad = stock.Cantidad
            });
        }

        return stocksDTO;
    }


}
