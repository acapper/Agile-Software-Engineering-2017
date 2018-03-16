using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile_2018;
using MySql.Data.MySqlClient;

namespace Agile_2018.Tests
{
    [TestClass]
    public class AddComment
    {
        [TestMethod]
        public void commentAddTest()
        {
            //pass through string
            string comment = "This is my comment";
            int projectID = 530;
            Comment myComment = new Comment();
            Assert.AreEqual(1, myComment.postComment(comment,projectID));
        }

        [TestMethod]
        public void getCommentTest()
        {
            //return expected string
            //string comes from default id
            string comment = "This is my comment";
            int projectID = 530;
            Comment myComment = new Comment();
            Assert.AreEqual(comment, myComment.getComment(projectID));
        }
    }
}
