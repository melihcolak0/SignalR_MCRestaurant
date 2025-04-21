using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace _81MY_SignalROrderManAPI.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IRestaurantTableService _restaurantTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;        

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IRestaurantTableService restaurantTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _restaurantTableService = restaurantTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendStatistics()
        {
            var value = _categoryService.TGetCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var value2 = _productService.TGetProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.TGetActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = _categoryService.TGetPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = _productService.TGetProductCountByCategoryName("Hamburger");
            await Clients.All.SendAsync("ReceiveProductCountByCategoryHamburger", value5);

            var value6 = _productService.TGetProductCountByCategoryName("İçecek");
            await Clients.All.SendAsync("ReceiveProductCountByCategoryDrink", value6);

            var value7 = _productService.TGetAvgProductPrice();
            await Clients.All.SendAsync("ReceiveAvgProductPrice", value7);

            var value8 = _productService.TGetProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveMaxPriceProduct", value8);

            var value9 = _productService.TGetProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveMinPriceProduct", value9);

            var value10 = _productService.TGetAvgProductPriceByHamburgers();
            await Clients.All.SendAsync("ReceiveAvgHamburgersPrice", value10);

            var value11 = _orderService.TGetOrderCount();
            await Clients.All.SendAsync("ReceiveOrderCount", value11);

            var value12 = _orderService.TGetActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

            var value13 = _orderService.TGetLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", value13);

            var value14 = _moneyCaseService.TGetMoneyCaseTotalAmount();
            await Clients.All.SendAsync("ReceiveMoneyCaseTotalAmount", value14);

            var value15 = _orderService.TGetTodaysTotalPrice();
            await Clients.All.SendAsync("ReceiveTodaysTotalPrice", value15);

            var value16 = _restaurantTableService.TGetRestaurantTableCount();
            await Clients.All.SendAsync("ReceiveRestaurantTableCount", value16);
        }

        public async Task SendProgresses()
        {
            var value = _moneyCaseService.TGetMoneyCaseTotalAmount();
            await Clients.All.SendAsync("ReceiveMoneyCaseTotalAmount", value);

            var value2 = _orderService.TGetActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value2);

            var value3 = _restaurantTableService.TGetRestaurantTableCount();
            await Clients.All.SendAsync("ReceiveRestaurantTableCount", value3);

            var value4 = _productService.TGetAvgProductPrice();
            await Clients.All.SendAsync("ReceiveAvgProductPrice", value4);

            var value5 = _productService.TGetAvgProductPriceByHamburgers();
            await Clients.All.SendAsync("ReceiveAvgProductPriceByHamburgers", value5);

            var value6 = _productService.TGetProductCountByCategoryName("İcecek");
            await Clients.All.SendAsync("ReceiveProductCountByDrink", value6);
        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetList();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        public async Task SendNotifications()
        {
            var value = _notificationService.TGetUnReadNotificationCount();
            await Clients.All.SendAsync("ReceiveUnReadNotificationCount", value);

            var unReadNotifs = _notificationService.TListUnReadNotifications();
            await Clients.All.SendAsync("ReceiveUnReadNotificationList", unReadNotifs);
        }

        public async Task GetRestaurantTableStatus()
        {
            var value = _restaurantTableService.TGetList();
            await Clients.All.SendAsync("ReceiveRestaurantTableStatus", value);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        static int clientCount = 0;
        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
