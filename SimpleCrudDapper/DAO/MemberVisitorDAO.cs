
using Dapper;
using SimpleCrudDapper.Models;
using SimpleCrudDapper.Utility;

namespace SimpleCrudDapper.DAO
{
    public class MemberVisitorDAO
    {
        private DbContext _context;
        public MemberVisitorDAO()
        {
            _context = new DbContext();
        }
        public int InsertVisitor(string code)
        {
            var query = @"INSERT visitor (member_id, visiting_date)
                        SELECT id, GETDATE() FROM member WHERE member_code = @CODE;
                        SELECT @@ROWCOUNT AS INSERTED";

            var param = new { CODE = code };
            using (var connection = _context.CreateConnection1())
            {
                try
                {
                    var data = connection.QueryFirstOrDefault<int>(query, param);
                    return data;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public List<object> GetAllData()
        {
            var query = @"SELECT visiting_date, member_code, M.name FROM visitor V
                          LEFT JOIN member M ON M.id = V.member_id";

            var param = new { };
            using (var connection = _context.CreateConnection1())
            {
                try
                {
                    var data = connection.Query(query, param).ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    return new List<object>();
                }
            }
        }
    }
}
