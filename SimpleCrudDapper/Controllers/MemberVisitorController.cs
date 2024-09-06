using Microsoft.AspNetCore.Mvc;
using SimpleCrudDapper.DAO;

namespace SimpleCrudDapper.Controllers
{
    public class MemberVisitorController : Controller
    {
        MemberVisitorDAO _dao;

        public MemberVisitorController()
        {
            _dao = new MemberVisitorDAO();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StoreVisitorData(string code)
        {
            int insert = _dao.InsertVisitor(code);
            if (insert == 0) {
                return Ok(new
                {
                    response = "Error",
                    message = "Member not found!"
                });
            }
            else
            {
                return Ok(new
                {
                    response = "Ok",
                    message = "Successfully!"
                });
            }
            
        }

        public IActionResult GetAllData() {
            List<object> data = _dao.GetAllData();
            return Ok(data);
        }
    }
}
