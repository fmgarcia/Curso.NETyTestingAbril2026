namespace Tienda.Core;

public class PedidoProcessor
{
    public async Task ProcesarAsync(int pedidoId)
    {
        await Task.Delay(10);

        if (pedidoId <= 0)
            throw new InvalidOperationException("El pedido no es valido.");
    }
}
