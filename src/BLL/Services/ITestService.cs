using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ITestService
    {
        Task InssertData();
    }
    
    public class TestService : ITestService
    {
        public async Task InssertData()
        {
            throw new System.NotImplementedException();
        }
    }
}