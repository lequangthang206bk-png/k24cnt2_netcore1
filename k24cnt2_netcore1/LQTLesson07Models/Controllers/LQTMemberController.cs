using Microsoft.AspNetCore.Mvc;
using LQTLesson07Models.Models.DataModels;

namespace LQTLesson07Models.Controllers
{
    public class LQTMemberController : Controller
    {
        protected static List<LQTMember> _members = new()
        {
            new LQTMember
            {
                LQTMemberId = Guid.NewGuid().ToString(),
                LQTUserName = "lqthang",
                LQTPassword = "123456",
                LQTFullName = "LQThang",
                LQTEmail = "lqthang@gmail.com"
            },
            new LQTMember
            {
                LQTMemberId = Guid.NewGuid().ToString(),
                LQTUserName = "lqt01",
                LQTPassword = "123456",
                LQTFullName = "LQT",
                LQTEmail = "lqt01@gmail.com"
            },
            new LQTMember
            {
                LQTMemberId = Guid.NewGuid().ToString(),
                LQTUserName = "lqt02",
                LQTPassword = "123456",
                LQTFullName = "LQThang",
                LQTEmail = "lqt02@gmail.com"
            }
        };

        public IActionResult Index()
        {
            return View(_members);
        }

        public IActionResult GetMember(string id)
        {
            var member = string.IsNullOrEmpty(id)
                ? new LQTMember
                {
                    LQTMemberId = Guid.NewGuid().ToString(),
                    LQTUserName = "lqthang",
                    LQTPassword = "123456",
                    LQTFullName = "LQThang",
                    LQTEmail = "lqthang@gmail.com"
                }
                : _members.FirstOrDefault(x => x.LQTMemberId == id);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        public IActionResult GetMembers()
        {
            ViewBag.Members = _members;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new LQTMember());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LQTMember member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);
            }

            member.LQTMemberId = Guid.NewGuid().ToString();
            _members.Add(member);
            TempData["Success"] = "Thêm thành viên thành công.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var member = _members.FirstOrDefault(x => x.LQTMemberId == id);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LQTMember member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);
            }

            var oldMember = _members.FirstOrDefault(x => x.LQTMemberId == member.LQTMemberId);

            if (oldMember == null)
            {
                return NotFound();
            }

            oldMember.LQTUserName = member.LQTUserName;
            oldMember.LQTPassword = member.LQTPassword;
            oldMember.LQTFullName = member.LQTFullName;
            oldMember.LQTEmail = member.LQTEmail;

            TempData["Success"] = "Cập nhật thành viên thành công.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var member = _members.FirstOrDefault(x => x.LQTMemberId == id);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var member = _members.FirstOrDefault(x => x.LQTMemberId == id);

            if (member == null)
            {
                return NotFound();
            }

            _members.Remove(member);
            TempData["Success"] = "Xóa thành viên thành công.";
            return RedirectToAction(nameof(Index));
        }
    }
}
