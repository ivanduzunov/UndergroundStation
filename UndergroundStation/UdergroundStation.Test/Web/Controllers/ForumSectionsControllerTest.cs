namespace UndergroundStation.Test.Web.Controllers
{
    using Xunit;
    using UndergroundStation.Web.Areas.Forum.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using FluentAssertions;
    using System.Linq;

    public class ForumSectionsControllerTest
    {
        [Fact]
        public void DetailsShouldBeOnlyForAuthorizedUsers()
        {
            //Arrange
            var method = typeof(SectionsController)
                  .GetMethod(nameof(SectionsController.Details));

            //Act
            var attributes = method
                            .GetCustomAttributes(true);

            //Assert
            attributes
                .Should()
                .Match(att => att.Any(a => a.GetType() == typeof(AuthorizeAttribute))); 

        }
    }
}
