using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using Massive;
using VidPub.Web.Model;

namespace VidPub.Tests
{

    [TestFixture]
    public class MembershipSpecs : TestBase
    {

        Users _membership;
        //DynamicModel _db;
        

        public MembershipSpecs()
        {
            this.Describes("User Registeration");
            _membership = new Users();
            //_db = new DynamicModel("Membership_Test", "Users", "ID");
        }


        [SetUp]
        public void Init()
        {
           //delete database -- start with fresh data for each test
            //_db.Delete();
            _membership.Delete();
        }
        /*
        [Test]
       public void registeration_should_not_accept_email_with_lt_6_chars()
        {
            this.IsPending();
        }

        [Test]
        public  void valid_email_and_password_should_register_user()
        {
            var membership = new Membership();
            var result = membership.Register("test@test.com", "password", "password");
            Assert.False(result.Success);
         
        }
      */ 
        [Test]
        public void user_should_be_saved_on_register()
        {
            var result = _membership.Register("hbtest@test.com", "password", "password");
            Assert.AreEqual(1, _membership.All().Count());
        }

        [Test]
        public void duplicate_email_should_return_message()
        {
            var result = _membership.Register("test@test.com", "password", "password");
            result = _membership.Register("test@test.com", "password", "password");
            Assert.AreEqual(result.Message, "This email already exists in our system");
        }


       
    }



}
