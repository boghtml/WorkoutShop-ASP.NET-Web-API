<h1 align="center">ASP.NET Core Web API Project</h1>

<h2>Project Description</h2>
<p>
    In this project, a RESTful API was developed using the <strong>ASP.NET Core</strong> platform. The goal of the project was to create the backend for a web application that allows users to perform various operations such as registration, authentication, viewing products, adding to the cart, and managing orders.
</p>

<h2>Table of Contents</h2>
<ul>
    <li><a href="#getting-started">Getting Started</a></li>
    <li><a href="#prerequisites">Prerequisites</a></li>
    <li><a href="#installation">Installation</a></li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#architecture">Architecture</a></li>
    <li><a href="#controllers">API Controllers</a></li>
    <li><a href="#authentication">Authentication and Authorization</a></li>
    <li><a href="#testing">Testing</a></li>
    <li><a href="#deployment">Deployment</a></li>
    <li><a href="#authors">Authors</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contacts">Contacts</a></li>
</ul>

<h2 id="getting-started">Getting Started</h2>
<p>
    This section will help you run the project on your local machine for development and testing purposes.
</p>

<h2 id="prerequisites">Prerequisites</h2>
<p>Before starting, ensure you have installed:</p>
<ul>
    <li><a href="https://dotnet.microsoft.com/download">.NET 6.0 SDK or newer</a></li>
    <li><a href="https://visualstudio.microsoft.com/">Visual Studio</a> or <a href="https://code.visualstudio.com/">Visual Studio Code</a></li>
    <li><a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads">SQL Server</a> or another compatible DBMS</li>
</ul>

<h2 id="installation">Installation</h2>
<ol>
    <li>Clone the repository:
        <pre><code>git clone https://github.com/yourusername/yourrepository.git</code></pre>
    </li>
    <li>Navigate to the project directory:
        <pre><code>cd yourrepository</code></pre>
    </li>
    <li>Open the project in your IDE (Visual Studio or Visual Studio Code).</li>
    <li>Install the necessary NuGet packages (they should install automatically upon opening the project).</li>
</ol>

<h2 id="usage">Usage</h2>
<h3>Database Configuration</h3>
<ol>
    <li>Edit the <code>appsettings.json</code> file to configure your database connection string:
        <pre><code>"ConnectionStrings": {
"DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;"
}</code></pre>
    </li>
    <li>Open the Package Manager Console or terminal and run the migrations:
        <pre><code>Update-Database</code></pre>
        or
        <pre><code>dotnet ef database update</code></pre>
    </li>
</ol>

<h3>Running the Application</h3>
<ol>
    <li>Run the project from your IDE or via command line:
        <pre><code>dotnet run</code></pre>
    </li>
    <li>The API will be available at <a href="https://localhost:5001">https://localhost:5001</a> or <a href="http://localhost:5000">http://localhost:5000</a>.</li>
    <li>Open Swagger UI to test the endpoints:
        <a href="https://localhost:5001/swagger">https://localhost:5001/swagger</a>
    </li>
</ol>

<h2 id="architecture">Architecture</h2>
<p>The project is built following the principles of layered architecture, which includes:</p>
<ul>
    <li><strong>Models</strong>: Database entities.</li>
    <li><strong>Controllers</strong>: Handling HTTP requests and responses.</li>
    <li><strong>Services</strong>: Business logic.</li>
    <li><strong>Repositories</strong>: Data access and interaction with the database.</li>
</ul>

<h2 id="controllers">API Controllers</h2>
<p>The main controllers include:</p>
<ul>
    <li><strong>AuthController</strong>: User registration and authentication.</li>
    <li><strong>ProductsController</strong>: Retrieving product lists and product details.</li>
    <li><strong>CategoriesController</strong>: Managing product categories.</li>
    <li><strong>CartController</strong>: Adding, updating, and removing items in the cart.</li>
    <li><strong>OrdersController</strong>: Creating and viewing orders.</li>
</ul>

<h2 id="authentication">Authentication and Authorization</h2>
<p>JWT authentication is used to protect endpoints:</p>
<ul>
    <li>Upon successful login, the user receives a JWT token.</li>
    <li>The token is used to access protected resources by adding it to the <code>Authorization</code> header with the <code>Bearer</code> prefix.</li>
    <li>The <code>[Authorize]</code> and <code>[AllowAnonymous]</code> attributes control access to controller methods.</li>
</ul>

<h2 id="testing">Testing</h2>
<p>You can use Swagger UI or other tools (e.g., Postman) to test the API:</p>
<ol>
    <li>Navigate to <a href="https://localhost:5001/swagger">https://localhost:5001/swagger</a>.</li>
    <li>Register a new user via the endpoint <code>/api/auth/register</code>.</li>
    <li>Log in via the endpoint <code>/api/auth/login</code> and obtain a JWT token.</li>
    <li>Copy the token and click the <strong>Authorize</strong> button in Swagger UI; paste the token with the <code>Bearer</code> prefix.</li>
    <li>You can now make requests to protected endpoints.</li>
</ol>

<h2 id="deployment">Deployment</h2>
<p>To deploy the application on a server or in a cloud environment:</p>
<ul>
    <li>Publish the project using the command:
        <pre><code>dotnet publish -c Release</code></pre>
    </li>
    <li>Set up a web server (e.g., IIS, Nginx) to host the application.</li>
    <li>Ensure the database connection string is correctly specified for the production environment.</li>
</ul>

<h2 id="authors">Authors</h2>
<p>The project was developed by a team of students as part of a course on software architecture and design.</p>

<h2 id="license">License</h2>
<p>This project is licensed under the MIT License - see the <code>LICENSE</code> file for details.</p>

<h2 id="contacts">Contacts</h2>
<p>If you have any questions or suggestions, please contact us:</p>
<ul>
    <li>Email: your.email@example.com</li>
    <li>GitHub: <a href="https://github.com/yourusername">github.com/yourusername</a></li>
</ul>

<h2>Detailed Project Description</h2>
<p>Below is a detailed description of the project, including setup, implementation, and testing.</p>

<h3>1. Initial Project Setup</h3>
<h4>1.1 Creating a New Project</h4>
<ul>
    <li>Using Visual Studio or Visual Studio Code, a new project of type <strong>ASP.NET Core Web API</strong> was created.</li>
    <li>The target framework selected was <strong>.NET 6.0</strong> or <strong>.NET 7.0</strong> (depending on relevance).</li>
    <li>The project was set up using the "API" template without authentication for further customization.</li>
</ul>

<h4>1.2 Setting Up Dependencies</h4>
<p>Necessary packages were added via NuGet Package Manager:</p>
<ul>
    <li><code>Microsoft.EntityFrameworkCore</code></li>
    <li><code>Microsoft.EntityFrameworkCore.SqlServer</code> (if using SQL Server)</li>
    <li><code>Microsoft.AspNetCore.Authentication.JwtBearer</code> for JWT authentication</li>
    <li><code>AutoMapper</code> for object-object mapping</li>
    <li>Other packages as needed (e.g., <code>Swashbuckle.AspNetCore</code> for Swagger documentation)</li>
</ul>

<h3>2. Database Setup and ORM</h3>
<h4>2.1 Creating Data Models</h4>
<p>Classes representing database entities were created:</p>
<ul>
    <li><strong>User</strong> — for storing user information</li>
    <li><strong>Product</strong> — for products</li>
    <li><strong>Category</strong> — for product categories</li>
    <li><strong>CartItem</strong> — for cart items</li>
    <li><strong>Order</strong> and <strong>OrderItem</strong> — for orders and their items</li>
</ul>

<h4>2.2 Configuring Entity Framework Core</h4>
<ul>
    <li>The database context <code>ApplicationDbContext</code> was created, inheriting from <code>DbContext</code>.</li>
    <li><code>DbSet</code> properties were defined for each entity in the context.</li>
    <li>Relationships between entities were configured using Fluent API or data annotations.</li>
</ul>

<h4>2.3 Migrations and Database Creation</h4>
<ul>
    <li>Using <strong>EF Core Migrations</strong>, migrations were created to build the database.</li>
    <li>The following commands were executed:
        <pre><code>Add-Migration InitialCreate</code></pre>
        or
        <pre><code>dotnet ef migrations add InitialCreate</code></pre>
        <pre><code>Update-Database</code></pre>
        or
        <pre><code>dotnet ef database update</code></pre>
    </li>
</ul>

<h3>3. Implementing API Controllers</h3>
<h4>3.1 Authentication Controller (<code>AuthController</code>)</h4>
<ul>
    <li><strong><code>Register</code> method</strong> for registering new users:
        <ul>
            <li>Accepts user data and creates a new record in the database.</li>
            <li>Uses Identity Framework for user management.</li>
        </ul>
    </li>
    <li><strong><code>Login</code> method</strong> for user authentication:
        <ul>
            <li>Verifies user credentials.</li>
            <li>Returns a JWT token for authorized requests.</li>
        </ul>
    </li>
</ul>

<h4>3.2 Products Controller (<code>ProductsController</code>)</h4>
<ul>
    <li><strong><code>GetProducts</code> method</strong> to retrieve a list of products:
        <ul>
            <li>Supports filtering, sorting, and pagination.</li>
        </ul>
    </li>
    <li><strong><code>GetProductById</code> method</strong> to retrieve product details by ID.</li>
</ul>

<h4>3.3 Categories Controller (<code>CategoriesController</code>)</h4>
<ul>
    <li>Methods to retrieve a list of categories and details of a specific category.</li>
</ul>

<h4>3.4 Cart Controller (<code>CartController</code>)</h4>
<ul>
    <li><strong><code>AddToCart</code> method</strong> to add a product to the cart:
        <ul>
            <li>Accepts product ID and quantity.</li>
            <li>Saves information in the database, linking it to the user.</li>
        </ul>
    </li>
    <li><strong><code>GetCartItems</code> method</strong> to retrieve the current cart items of the user.</li>
    <li><strong><code>UpdateCartItem</code> and <code>RemoveFromCart</code> methods</strong> to update and remove cart items.</li>
</ul>

<h4>3.5 Orders Controller (<code>OrdersController</code>)</h4>
<ul>
    <li><strong><code>CreateOrder</code> method</strong> to create a new order:
        <ul>
            <li>Creates an order record based on the items in the user's cart.</li>
            <li>Clears the cart after order creation.</li>
        </ul>
    </li>
    <li><strong><code>GetOrders</code> method</strong> to retrieve a list of the user's orders.</li>
    <li><strong><code>GetOrderById</code> method</strong> to retrieve details of a specific order.</li>
</ul>

<h3>4. Setting Up Authentication and Authorization</h3>
<h4>4.1 Configuring JWT Authentication</h4>
<ul>
    <li>In the <code>Program.cs</code> or <code>Startup.cs</code> file, configuration was added to use JWT:
        <ul>
            <li>Token parameters such as signing key, issuer, and audience were specified.</li>
            <li>The <code>AddAuthentication</code> service was configured using <code>JwtBearer</code>.</li>
        </ul>
    </li>
</ul>

<h4>4.2 Protecting Routes</h4>
<ul>
    <li>The <code>[Authorize]</code> attribute was applied to controllers and methods that require authentication.</li>
    <li>Anonymous access was allowed to registration and login methods using the <code>[AllowAnonymous]</code> attribute.</li>
</ul>

<h3>5. Setting Up AutoMapper</h3>
<ul>
    <li>The <code>AutoMapper</code> and <code>AutoMapper.Extensions.Microsoft.DependencyInjection</code> packages were installed.</li>
    <li>Mapping profiles were created to convert between domain models and DTOs (Data Transfer Objects).</li>
    <li>Mapping was configured in <code>Program.cs</code> or <code>Startup.cs</code>.</li>
</ul>

<h3>6. API Documentation with Swagger</h3>
<ul>
    <li>The <code>Swashbuckle.AspNetCore</code> package was installed.</li>
    <li>Swagger was enabled in the project:
        <ul>
            <li>Added <code>AddSwaggerGen</code> services in <code>Program.cs</code> or <code>Startup.cs</code>.</li>
            <li>Configured middleware <code>UseSwagger</code> and <code>UseSwaggerUI</code>.</li>
        </ul>
    </li>
    <li>Endpoints were documented using XML comments and attributes.</li>
</ul>

<h3>7. API Testing</h3>
<ul>
    <li>Tools like Postman or Swagger UI were used to test API endpoints.</li>
    <li>The following scenarios were tested:
        <ul>
            <li>User registration and login.</li>
            <li>Retrieving product lists and product details.</li>
            <li>Adding products to the cart and managing them.</li>
            <li>Creating orders and viewing order history.</li>
        </ul>
    </li>
</ul>

<h3>8. Error Handling and Logging</h3>
<ul>
    <li>Global exception handling was added using the <code>UseExceptionHandler</code> middleware.</li>
    <li>Logging was configured using the built-in logger or third-party libraries (e.g., Serilog).</li>
</ul>

<h3>9. Deployment</h3>
<ul>
    <li>The application was prepared for deployment on a server or cloud service (e.g., Azure).</li>
    <li>Configuration files were set up for different environments (Development, Production).</li>
</ul>


<h2>Results:</h2>

![image](https://github.com/user-attachments/assets/1ce7185f-47d0-4d5a-ba6d-0eb285ae9c6f)
![image](https://github.com/user-attachments/assets/423d1cb6-5a44-4a48-a06f-b9f137d3e427)
![image](https://github.com/user-attachments/assets/6950ead5-71c5-43b3-bb2f-694304246837)
![image](https://github.com/user-attachments/assets/bde5cce9-cdd3-49e1-b1c1-9a8993bd9944)
![image](https://github.com/user-attachments/assets/38445cd5-5a95-4dde-9d21-ee51c9c0a0a2)

