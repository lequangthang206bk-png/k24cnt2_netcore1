using Microsoft.AspNetCore.Mvc;
using LqtLesson08Models.Models;

namespace LqtLesson08Models.Controllers
{
    public class LqtMemberController : Controller
    {
        private static List<LqtMember> _members = new List<LqtMember>()
        {
            new LqtMember
            {
                LqtMemberId = Guid.NewGuid().ToString(),
                LqtUserName = "lqThang",
                LqtPassword = "PassLqThang2026!",
                LqtFullName = "Lê Quang Thắng",
                LqtEmail = "lequangthang@gmail.com"
            },
            new LqtMember
            {
                LqtMemberId = Guid.NewGuid().ToString(),
                LqtUserName = "tranthib",
                LqtPassword = "SecurePass456#",
                LqtFullName = "Trần Thị B",
                LqtEmail = "tranthib@outlook.com"
            },
            new LqtMember
            {
                LqtMemberId = Guid.NewGuid().ToString(),
                LqtUserName = "levanc",
                LqtPassword = "MyPassword789$",
                LqtFullName = "Lê Văn C",
                LqtEmail = "levanc@company.com"
            }
        };

        public IActionResult Index()
        {
            return View(_members);
        }

        [HttpGet]
        public IActionResult LqtCreate()
        {
            var member = new LqtMember();
            return View(member);
        }

        [HttpPost]
        public IActionResult LqtCreate(LqtMember lqtMember)
        {
            lqtMember.LqtMemberId = Guid.NewGuid().ToString();
            _members.Add(lqtMember);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult LqtEdit(string id)
        {
            var member = _members.FirstOrDefault(x => x.LqtMemberId.Equals(id));
            return View(member);
        }

        [HttpPost]
        public IActionResult LqtEdit(string id, LqtMember lqtMember)
        {
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].LqtMemberId == id)
                {
                    _members[i].LqtUserName = lqtMember.LqtUserName;
                    _members[i].LqtPassword = lqtMember.LqtPassword;
                    _members[i].LqtFullName = lqtMember.LqtFullName;
                    _members[i].LqtEmail = lqtMember.LqtEmail;
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult LqtDetails(string id)
        {
            var member = _members.FirstOrDefault(x => x.LqtMemberId.Equals(id));
            return View(member);
        }

        [HttpGet]
        public IActionResult LqtDelete(string id)
        {
            var member = _members.FirstOrDefault(x => x.LqtMemberId.Equals(id));
            return View(member);
        }

        [HttpPost]
        public IActionResult LqtDeleted(string id)
        {
            foreach (var item in _members)
            {
                if (item.LqtMemberId.Equals(id))
                {
                    _members.Remove(item);
                    return RedirectToAction("Index");
                }
            }
            return View("LqtDelete");
        }
    }
}
