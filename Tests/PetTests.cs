using System.Collections.Generic;
using TesteAPINuri.Services;
using Xunit;
using Xunit.Abstractions;

namespace TesteAPINuri.Tests
{
    public class PetTests
    {
        private readonly ITestOutputHelper output;

        public PetTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = "Post upload image by ID")] //Upload an image using an ID
        [Trait(" category", "pet")]
        public void Post_uploadImgById()
        {
            new PetServiceWorkFlow(output).Validate_PostupImgWithId(1);
        }

        [Fact(DisplayName = "Post upload image fixed Id")] //Upload an image using the first element of a list
        [Trait("category", "pet")]
        public void Post_uploadImgFixedId()
        {
            new PetServiceWorkFlow(output).Validate_PostupImgFixed();
        }

        [Fact(DisplayName = "Post new Pet")]
        [Trait("category", "pet")]
        public void Post_newPet()
        {
            new PetServiceWorkFlow(output).Validate_PostNewPet(CustomConfigurationProvider.GetSection("addPet"));
        }

        [Fact(DisplayName = "Put Modify a Existing Pet")]
        [Trait("category", "pet")]
        public void Put_ModifyPet()
        {
            new PetServiceWorkFlow(output).Validate_PutModifyPet(CustomConfigurationProvider.GetSection("ModifyPet"));
        }

        //Method 1, randomly hitting you possíveis status

        [Fact(DisplayName = "Get All Pet Find by Status")]
        [Trait("categoty", "pet")]
        public void Get_PetFindByStatus()
        {
            List<string> status = new List<string>();
            status.Add(CustomConfigurationProvider.GetSection("status.val1"));
            status.Add(CustomConfigurationProvider.GetSection("status.val2"));
            status.Add(CustomConfigurationProvider.GetSection("status.val3"));
            new PetServiceWorkFlow(output).Validate_GetAllPetFindByStatusRandom(status);
        }

        //Method 2, specifically pasting the status types

        [Fact(DisplayName = "Get All Pet Find by Sold")]
        [Trait("categoty", "pet")]
        public void Get_PetFindByStatusBySold()
        {

            new PetServiceWorkFlow(output).Validate_GetAllPetFindByStatus(CustomConfigurationProvider.GetSection("status.val1"));
        }

        [Fact(DisplayName = "Get All Pet Find by Avaliable")]
        [Trait("categoty", "pet")]
        public void Get_PetFindByStatusByAvaliable()
        {
            new PetServiceWorkFlow(output).Validate_GetAllPetFindByStatus(CustomConfigurationProvider.GetSection("status.val2"));
        }

        [Fact(DisplayName = "Get All Pet Find by Pending")]
        [Trait("categoty", "pet")]
        public void Get_PetFindByStatusByPending()
        {
            new PetServiceWorkFlow(output).Validate_GetAllPetFindByStatus(CustomConfigurationProvider.GetSection("status.val3"));
        }

        //PET FIND BY ID
        [Fact(DisplayName = "Get Pet by Id")]
        [Trait("category", "pet")]
        public void Get_PetById()
        {
            new PetServiceWorkFlow(output).Validate_GetPetById(int.Parse(CustomConfigurationProvider.GetSection("id")));
        }

        //Pasting an invalid id and receiving an error
        [Fact(DisplayName = "Get Bad Request by Id")]
        [Trait("category", "pet")]
        public void Get_BadRequestById()
        {
            new PetServiceWorkFlow(output).Validade_Error_GetPetById(int.Parse(CustomConfigurationProvider.GetSection("invalidId")));
        }

    }
}
