# Portfolio Website - ASP.NET Core

A modern, professional portfolio website built with ASP.NET Core 8.0 and Razor Pages.

## Features

- ✨ Modern, responsive design
- 🎨 Gradient hero section with smooth animations
- 📊 Dynamic skills visualization with progress bars
- 💼 Featured projects showcase
- 📱 Mobile-friendly navigation
- 🚀 Fast and lightweight

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Local Development

1. Clone the repository
2. Navigate to the project directory
3. Run the application:

```bash
dotnet restore
dotnet run
```

4. Open your browser to `https://localhost:5001` or `http://localhost:5000`

## Customization

### Update Personal Information

Edit `Pages/Index.cshtml.cs` to update:
- Your name
- Title/role
- Bio
- Projects
- Skills
- Contact information

### Modify Styling

Edit `wwwroot/css/site.css` to customize:
- Colors (see CSS variables at the top)
- Fonts
- Spacing
- Layout

## Deployment Options

### Option 1: Azure App Service (Recommended)

1. **Create Azure Account** (free tier available)
   - Visit [azure.microsoft.com](https://azure.microsoft.com)

2. **Install Azure CLI** (or use Azure Portal)
   ```bash
   # Login to Azure
   az login
   
   # Create a resource group
   az group create --name portfolio-rg --location eastus
   
   # Create an App Service plan
   az appservice plan create --name portfolio-plan --resource-group portfolio-rg --sku F1 --is-linux
   
   # Create the web app
   az webapp create --name workwithnitish --resource-group portfolio-rg --plan portfolio-plan --runtime "DOTNETCORE:8.0"
   
   # Deploy
   dotnet publish -c Release
   cd bin/Release/net8.0/publish
   zip -r deploy.zip .
   az webapp deployment source config-zip --resource-group portfolio-rg --name workwithnitish --src deploy.zip
   ```

3. **Configure Custom Domain**
   - In Azure Portal, go to your App Service
   - Click "Custom domains"
   - Add `workwithnitish.dev`
   - Update DNS records at your domain registrar:
     - Add CNAME: `www` → `workwithnitish.azurewebsites.net`
     - Add A record: `@` → (IP provided by Azure)

### Option 2: Docker + Any Cloud Provider

1. **Create Dockerfile** (already included below):

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PortfolioWebsite.csproj", "./"]
RUN dotnet restore
COPY . .
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PortfolioWebsite.dll"]
```

2. **Build and run**:
```bash
docker build -t portfolio .
docker run -p 8080:80 portfolio
```

### Option 3: GitHub Pages + GitHub Actions (Static Export)

For static hosting, you'll need to convert to Blazor WASM or export as static HTML.

### Option 4: Railway.app / Render.com (Easy Deployment)

1. **Railway.app**:
   - Connect your GitHub repo
   - Railway auto-detects .NET
   - Add custom domain in settings

2. **Render.com**:
   - Create new Web Service
   - Connect GitHub repo
   - Build command: `dotnet publish -c Release`
   - Start command: `dotnet bin/Release/net8.0/publish/PortfolioWebsite.dll`

## Connecting Your Domain (workwithnitish.dev)

### DNS Configuration

Regardless of hosting provider, you'll need to configure DNS at your domain registrar:

**For most providers:**
```
Type: A
Name: @
Value: [Your hosting provider's IP]

Type: CNAME
Name: www
Value: [Your hosting provider's domain]
```

**Specific providers:**

- **Namecheap**: Advanced DNS → Add records
- **GoDaddy**: DNS Management → Add records
- **Cloudflare**: DNS → Add records

## SSL Certificate

Most modern hosting providers (Azure, Railway, Render) provide free SSL certificates automatically.

## Project Structure

```
PortfolioWebsite/
├── Pages/
│   ├── Shared/
│   │   └── _Layout.cshtml
│   ├── Index.cshtml
│   ├── Index.cshtml.cs
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   └── js/
│       └── site.js
├── Program.cs
├── PortfolioWebsite.csproj
└── appsettings.json
```

## Technologies Used

- ASP.NET Core 8.0
- Razor Pages
- HTML5/CSS3
- JavaScript (Vanilla)
- Google Fonts (Inter)

## License

MIT License - feel free to use this for your own portfolio!

## Support

For issues or questions, please open an issue on GitHub.
