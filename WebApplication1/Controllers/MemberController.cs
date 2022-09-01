using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.NetworkInformation;
using System.Security.Principal;
using WebApplication1.Models;
using Microsoft.AspNetCore.Session;

namespace WebApplication1.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string _userID,string _userPW, string _PWcheck)
        {
            string userID = _userID, userPW = _userPW, PWcheck = _PWcheck; 
            //檢查密碼是否輸入正確
            if(userPW != PWcheck)
            {
                ViewBag.wrongPWcheck = true;
                return View();
            }
            else
            {

                Member member = new Member(userID, userPW);
                //檢查ID是否重複
                MemberConnection memberConnection = new MemberConnection();
                if (memberConnection.isIdUsed(member.userID))
                {
                    ViewBag.IDCheck = true;
                    return View();
                }
                else
                {
                    memberConnection.register(member);
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string _userID, string _userPW)
        {
            Member member = new Member(_userID, _userPW);
            MemberConnection memberConnection = new MemberConnection();
            //確認帳號是否存在

            //確認密碼是否輸入正確
            if(memberConnection.isIdUsed(member.userID)&&memberConnection.passwordCheck(member.userID, member.userPW))
            {
                HttpContext.Session.SetString("userID", member.userID);

                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewBag.inputError = true;
                return View();
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
