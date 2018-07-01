using ContactInformation.Controllers.Api;
using ContactInformation.Core;
using ContactInformation.Core.Repositories;
using ContactInformation.Tests.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace ContactInformation.Tests.Api
{
    [TestClass]
    public class ContactsControllerTests
    {
        private ContactsController _contactsController;

        public ContactsControllerTests()
        {
            var mockRepository = new Mock<IContactRepository>();

            var mockUoW = new Mock<IUnitofWork>();

            _contactsController = new ContactsController(mockUoW.Object);
            _contactsController.MockCurrentUser("1", "user1@domain.com");
        }


        [TestMethod]
        public void Cancel_NoContactIdExists_ShouldReturnnotFound()
        {
            var result = _contactsController.Cancel(1);

            result.Should().BeOfType<NotFoundResult>();
        }

    }
}
