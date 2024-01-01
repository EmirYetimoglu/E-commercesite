using System.Collections;
class Program
{
    static void AddProductToHashtable(Hashtable hashtable, int productId, string productName, decimal price)
    {
        Product product = new Product { PId = productId, PName = productName, Price = price };
        hashtable.Add(productId, product);
    }
    static Product GetProductById(Hashtable hashtable, int productId)
    {
        if (hashtable.ContainsKey(productId))
        {
            return (Product)hashtable[productId];
        }
        else
        {
            return null;
        }
    }


    static void Main()
    {
        ECommerceSystem ecommerceSystem = new ECommerceSystem();
        Cart userCart = new Cart();
        Hashtable Producthastable = new Hashtable();

        // Adding Products to Hashtable
        AddProductToHashtable(Producthastable, 1, "iPhone 11 128 Gb", 24.999m);
        AddProductToHashtable(Producthastable, 2, "iPhone 12 128 Gb ", 30.000m);
        AddProductToHashtable(Producthastable, 3, "Samsung Galaxy S23 FE 5g 8/256 Gb", 23.999m);
        AddProductToHashtable(Producthastable, 4, "SAMSUNG GALAXY A34 8/256 GB", 13.988m);
        AddProductToHashtable(Producthastable, 5, "Lenovo Ideapad 3", 11.999m);
        AddProductToHashtable(Producthastable, 6, "Asus Vivobook 16X ", 29.144m);
        AddProductToHashtable(Producthastable, 7, "Acer Aspire 5  ", 16.033m);
        AddProductToHashtable(Producthastable, 8, "JBL Quantum 100 Gaming Headset", 749m);
        AddProductToHashtable(Producthastable, 9, "JBL Tune 570BT", 1.549m);
        AddProductToHashtable(Producthastable, 10, "SAMSUNG Galaxy Buds2", 1.999m);
        AddProductToHashtable(Producthastable, 11, "Apple MTJV3TU/A Airpods Pro", 7.299m);
        AddProductToHashtable(Producthastable, 12, "LG 55UR81006 55inc 139 cm 4K  ", 27.000m);
        AddProductToHashtable(Producthastable, 13, "SAMSUNG UE 50CU7000 50inc 125 cm 4K UHD ", 37.999m);
        AddProductToHashtable(Producthastable, 14, "VESTEL 70Q9700TT 70inc 178 cm 4K UHD Android Smart QLED TV", 25.000m);
        AddProductToHashtable(Producthastable, 15, "LG 55QNED81 55inc 139 cm 4K webOS Smart TV ", 37.999m);

        // Creating Categories
        Category PhonesCategory = new Category { CategoryId = 1, CategoryName = "Phones" };
        Category laptopsCategory = new Category { CategoryId = 2, CategoryName = "Laptops" };
        Category EarphonesCategory = new Category { CategoryId = 3, CategoryName = "Earphones" };
        Category TvCategory = new Category { CategoryId = 4, CategoryName = "Televisions" };

        // Adding categories to EcommerceSystem
        ecommerceSystem.AddCategory(PhonesCategory);
        ecommerceSystem.AddCategory(laptopsCategory);
        ecommerceSystem.AddCategory(EarphonesCategory);
        ecommerceSystem.AddCategory(TvCategory);

        //Adding products to categories
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 1), PhonesCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 2), PhonesCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 3), PhonesCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 4), PhonesCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 5), laptopsCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 6), laptopsCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 7), laptopsCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 8), EarphonesCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 9), EarphonesCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 10), EarphonesCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 11), EarphonesCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 12), TvCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 13), TvCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 14), TvCategory);
        ecommerceSystem.AddProduct(GetProductById(Producthastable, 15), TvCategory);
        // Creating Users
        ecommerceSystem.Users.Add(new User { UserId = 1, UserName = "John Doe" });
        ecommerceSystem.Users.Add(new User { UserId = 2, UserName = "Jane Doe" });
        ecommerceSystem.Users.Add(new User { UserId = 3, UserName = "Carlo Joseph" });
        ecommerceSystem.Users.Add(new User { UserId = 4, UserName = "Scott Finley" });
        ecommerceSystem.Users.Add(new User { UserId = 5, UserName = "Zain Holmes" });
        ecommerceSystem.Users.Add(new User { UserId = 6, UserName = "Angel Mcleod" });
        ecommerceSystem.Users.Add(new User { UserId = 7, UserName = "Dan Cordova" });

        //Purchase history wroten manually
        Dictionary<int, List<int>> userPurchaseHistory = new Dictionary<int, List<int>>();
        userPurchaseHistory.Add(1, new List<int> { 1, 8 });//User 1 purchase history
        userPurchaseHistory.Add(2, new List<int> { 2, 5 });//User 2 purchase history
        userPurchaseHistory.Add(3, new List<int> { 12, 5 });//User 3 purchase history
        userPurchaseHistory.Add(4, new List<int> { 3, 9 });//User 4 purchase history
        userPurchaseHistory.Add(5, new List<int> { 1, 2, 8 });//User 5 purchase history
        userPurchaseHistory.Add(6, new List<int> { 15, 4 });//User 6 purchase history
        userPurchaseHistory.Add(7, new List<int> { 2, 10 });//User 7 purchase history



        //Display Users
        Console.WriteLine("Users in the system:");
        foreach (var user in ecommerceSystem.Users)
        {
            Console.WriteLine($"UserID: {user.UserId}, UserName: {user.UserName}");
        }


        //Select user
        Console.Write("Enter User Id: ");
        int userId = int.Parse(Console.ReadLine());
        User currentUser = ecommerceSystem.GetUserById(userId);
        Console.Clear();

        if (currentUser == null)
        {
            Console.WriteLine("User not found");

        }
        else if (currentUser != null)
        {
            Console.WriteLine($"User found - UserID: {currentUser.UserId}, UserName: {currentUser.UserName}");
        }



        //Display Categories
        Console.WriteLine("Categories:");
        foreach (var category in ecommerceSystem.Categories)
        {
            Console.WriteLine($"CategoryID: {category.CategoryId}, CategoryName: {category.CategoryName}");
        }
        bool continueProductSelection = true;


        //Select Category with outer loop
        while (true)
        {
            Console.Write("Enter Category Id: ");
            int categoryID = int.Parse(Console.ReadLine());
            Category currentCategory = ecommerceSystem.GetCategoryByID(categoryID);

            if (currentCategory == null)
            {
                Console.WriteLine("Category not Found");
                return;
            }
            else
            {
                Console.WriteLine($"Category Found - CategoryID: {currentCategory.CategoryId}, CategoryName: {currentCategory.CategoryName}");
                Console.WriteLine($"Products in {currentCategory.CategoryName} category:");
                foreach (var product in currentCategory.Products)
                {
                    Console.WriteLine($"ProductID: {product.PId}, ProductName: {product.PName}, Price: {product.Price}");
                }
            }


            //Select Product to buy and create a loop for buy more than 1 product

            while (true)
            {
                Console.Write("Enter product Id to add to the cart (or if you want to select another category wrote exit):");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    // Exit the product selection loop
                    break;
                }
                else if (int.TryParse(input, out int productId))
                {
                    Product selectedProduct = currentCategory.Products.FirstOrDefault(p => p.PId == productId);

                    if (selectedProduct == null)
                    {
                        Console.WriteLine("Please select a valid product and try again.");
                    }
                    else
                    {
                        userCart.AddtoCart(selectedProduct);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid Product Id or 'exit'.");
                }
            }

            Console.Write("Do you want to select another category? (yes/no): ");
            string response = Console.ReadLine()?.ToLower();
            if (response != "yes")
            {
                break;
            }

            Console.Clear();
            Console.WriteLine("Available Categories:");
            foreach (var category in ecommerceSystem.Categories)
            {
                Console.WriteLine($"CategoryID: {category.CategoryId}, CategoryName: {category.CategoryName}");
            }




        }


        userCart.DisplayCart(); // Displays cart before exiting
        List<int> currentUserPurchaseHistory = userPurchaseHistory.ContainsKey(userId) ? userPurchaseHistory[userId] : new List<int>();

        // Get product recommendations for the current user
        List<int> productRecommendations = GetProductRecommendations(userPurchaseHistory, userId, userCart.Cartitems.Select(item => item.PId).ToList());

        // Display product recommendations
        Console.WriteLine("Product Recommendations:");
        foreach (var productId in productRecommendations)
        {
            Product recommendedProduct = GetProductById(Producthastable, productId);
            Console.WriteLine($"ProductID: {recommendedProduct.PId}, ProductName: {recommendedProduct.PName}, Price: {recommendedProduct.Price}");
        }

        //Ask user if he/she wants to add one of the recommended product to cart
        Console.Write("Do you want to add a recommended product to the cart? (Enter Product Id or 'exit'):");
        string input1 = Console.ReadLine();
        if (input1.ToLower() != "exit" && int.TryParse(input1, out int selectedProductId))
        {
            Product selectedProduct = GetProductById(Producthastable, selectedProductId);

            if (selectedProduct != null)
            {
                userCart.AddtoCart(selectedProduct);
            }
            else
            {
                Console.WriteLine("Invalid Product Id. Please enter again");
            }
        }
        Console.Clear() ;
        userCart.DisplayCart();
        decimal totalCartPrice = userCart.Cartitems.Sum(product => product.Price);
        Console.WriteLine($"Total Price in the Cart: {totalCartPrice}");


    }

    static List<int> GetProductRecommendations(Dictionary<int, List<int>> userPurchaseHistory, int userId, List<int> currentCart)
    {
        // Finds similar purchase histories of users
        var similarUsers = userPurchaseHistory
        .Where(entry => entry.Key != userId) 
        .OrderByDescending(entry => entry.Value.Intersect(userPurchaseHistory[userId]).Count()) 
        .Select(entry => entry.Key)
        .Take(3) 
        .ToList();

        // Combines purchase histories
        var combinedHistory = similarUsers.SelectMany(user => userPurchaseHistory[user]).Distinct();

        // With this code program will not give recommendations which is already in cart
        var uniqueRecommendations = combinedHistory.Except(userPurchaseHistory[userId]).Except(currentCart);

        // Takes top recommendations
        var topRecommendations = uniqueRecommendations.Take(5).ToList();

        return topRecommendations;
    }




}


