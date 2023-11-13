namespace Infra.ConexaoComBanco;

public class ControladorDeRotaDoBancoDeDados
{
    public static string Conexao()
    {
        return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EcoCloud;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }

    public static string ConexaoHangFire()
    {
        return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EcoCloudHangfire;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
