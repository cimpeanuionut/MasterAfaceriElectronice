namespace Applicatie
{
    public static class RouteConfig
    {
        private const string
            addRoute = "New"
            , editRoute = "Edit/{0}"
            , deleteRoute = "Delete/{0}"
            ;

        public static class ProductTypeRoutes
        {
            private const string ControllerName = "/ProductType";

            public const string
                CreateRoute = ControllerName + "/" + addRoute
                , EditRoute = ControllerName + "/" + editRoute
                , DeleteRoute = ControllerName + "/" + deleteRoute
                ;
        }

        public static class ProductRoutes
        {
            private const string ControllerName = "/Product";

            public const string
                CreateRoute = ControllerName + "/" + addRoute
                , EditRoute = ControllerName + "/" + editRoute
                , DeleteRoute = ControllerName + "/" + deleteRoute
                , GetRoute = ControllerName
                ;
        }

        public static class SpecialTagRoutes
        {
            private const string ControllerName = "/SpecialTag";

            public const string
                CreateRoute = ControllerName + "/" + addRoute
                , EditRoute = ControllerName + "/" + editRoute
                , DeleteRoute = ControllerName + "/" + deleteRoute
                ;
        }

        public static class UserRoutes
        {
            private const string ControllerName = "/User";

            public const string
                CreateRoute = ControllerName + "/" + addRoute
                , EditRoute = ControllerName + "/" + editRoute
                , DeleteRoute = ControllerName + "/" + deleteRoute
                , GetRoute = ControllerName
                , LoginRoute = ControllerName + "/Login"
                ;
        }

        public static class HomeRoutes
        {
            private const string ControllerName = "/Home";

            public const string
                DetailsRoute = "/Details/{0}"
                , AddToBagRoute = "/Add/{0}"
                , RemoveFromBagRoute = "/Remove/{0}"
                , SubmitFeedbackRoute = "/SubmitFeedback"
                ;
        }
    }
}
