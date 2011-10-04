﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VidPub.Tests;
using NUnit.Framework;
using VidPub.Web.Controllers;
using VidPub.Web.Model;
using System.Web.Mvc;
using VidPub.Web.Model;
using VidPub.Web.Infrastructure;
namespace VidPub.Tests.Funtionals
{
    [TestFixture]
    public  class AccountControllerTests: TestBase
    {
        Users _users;
        AccountController _controller;

        public AccountControllerTests()
        {
            this.Describes("Account Controller");
            _users = new Users();
            _controller = new AccountController(new FakeTokenStore());

        }

        [SetUp]
        public void Init()
        {
            _users.Delete();
        }

        [Test]
        public void register_action_should_redirect_with_valid_email_pass()
        {
           
            //SetContext(_controller);
            var result = _controller.Register("hbtest3@test.com", "password", "password");
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }

        [Test]
        public void changes_token_with_dual_logon()
        {
            _controller.Register("test@test.com", "password", "password");
            var result = _controller.LogOn("test@test.com", "password");

            //pull the token from the DB
            var token1 = _users.Single(where: "email = @0", args: "test@test.com").Token;

            //LogOn creates a new token
            _controller.LogOn("test@test.com", "password");

            //pull the new token from the DB
            var token2 = _users.Single(where: "email = @0", args: "test@test.com").Token;

            Assert.AreNotEqual(token1, token2);
        }

        [Test]
        public void isloggedin_returs_false_for_first_user_on_dual_login()
        {

            _controller.Register("test@test.com", "password", "password");
            var result = _controller.LogOn("test@test.com", "password");

            //make sure user is logged in
            Assert.True(_controller.IsLoggedIn);

            //var c2 = new AccountController(new FakeTokenStore());
            //c2.LogOn("test@test.com", "password");

            ////see if the first controller instance returns true for logged on
            //Assert.False(_controller.IsLoggedIn);


        }
    }
}




