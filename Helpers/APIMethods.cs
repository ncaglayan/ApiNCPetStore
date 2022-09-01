namespace TesteAPINuri.Helpers
{
    class APIMethods
    {

        //GROUP PET:
        public static string PetId
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("petStoreService-baseUrl")}" + "pet/";
            }
        }

        public static string NewPet
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("petStoreService-baseUrl")}" + "pet";
            }
        }

        public static string PetFindByStatus
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("petStoreService-baseUrl")}" + "pet/findByStatus";
            }
        }

        //GROUP STORE:
        public static string StoreOrder
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("petStoreService-baseUrl")}" + "store/order/";
            }
        }

        public static string StoreInventory
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("petStoreService-baseUrl")}" + "store/inventory";
            }
        }

        //GROUP USER:
        public static string UserNameGet
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("petStoreService-baseUrl")}" + "user/";
            }
        }

        public static string UserLogin
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("petstoreService-baseUrl")}" + "user/login";
            }
        }

        public static string UserLogout
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("petstoreService-baseUrl")}" + "user/logout";
            }
        }

        public static string PostUser
        {
            get
            {
                return $"{CustomConfigurationProvider.GetKey("petStoreService-baseUrl")}" + "user";
            }
        }
    }
}
