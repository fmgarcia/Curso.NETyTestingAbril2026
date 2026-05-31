namespace Tienda.Core;

public interface IEmailSender
{
    Task EnviarAsync(string destino, string asunto, string cuerpo);
}

public class PedidoService
{
    private readonly IEmailSender _emailSender;

    public PedidoService(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public async Task ConfirmarPedidoAsync(string email)
    {
        await _emailSender.EnviarAsync(email, "Pedido confirmado", "Gracias por tu compra");
    }
}
