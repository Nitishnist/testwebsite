# 🚀 Quick Start Guide - Deploy to workwithnitish.dev

## Fastest Way to Deploy (5 minutes)

### Option A: Azure App Service (Recommended - Free Tier Available)

1. **Create Azure Account**
   - Go to [portal.azure.com](https://portal.azure.com)
   - Sign up (free $200 credit for 30 days)

2. **Deploy Using VS Code** (Easiest)
   - Install "Azure App Service" extension in VS Code
   - Right-click project → "Deploy to Web App"
   - Create new Web App: `workwithnitish`
   - Select Linux + .NET 8
   - Wait for deployment (2-3 minutes)

3. **Add Custom Domain**
   - In Azure Portal → Your App Service → Custom domains
   - Click "Add custom domain"
   - Enter `workwithnitish.dev`
   - Copy the DNS records shown
   - Add them to your domain registrar (where you bought the domain)

### Option B: Railway.app (Fastest - 2 minutes)

1. **Push to GitHub**
   ```bash
   git init
   git add .
   git commit -m "Initial commit"
   git remote add origin YOUR_GITHUB_REPO
   git push -u origin main
   ```

2. **Deploy on Railway**
   - Go to [railway.app](https://railway.app)
   - Click "Start a New Project"
   - Select "Deploy from GitHub repo"
   - Choose your repository
   - Railway auto-detects .NET and deploys

3. **Add Custom Domain**
   - Click Settings → Domains
   - Add `workwithnitish.dev`
   - Update DNS at your domain registrar:
     - CNAME: `www` → `[your-app].railway.app`
     - A: `@` → Railway's IP (shown in settings)

### Option C: Render.com (Also Free)

1. **Push to GitHub** (same as above)

2. **Deploy on Render**
   - Go to [render.com](https://render.com)
   - New → Web Service
   - Connect your GitHub repo
   - Build command: `dotnet publish -c Release -o out`
   - Start command: `dotnet out/PortfolioWebsite.dll`
   - Click "Create Web Service"

3. **Add Domain**
   - Settings → Custom Domain
   - Add `workwithnitish.dev`
   - Update DNS records as shown

## DNS Configuration

Once you've deployed, update these records at your domain registrar:

**Example for most providers:**
```
Type: A
Name: @
Value: [IP from your hosting provider]

Type: CNAME  
Name: www
Value: [domain from your hosting provider]
```

**Wait time:** DNS changes take 5 minutes to 48 hours (usually ~30 minutes)

## Verify Deployment

1. Check `http://[your-temp-url]` works (e.g., `workwithnitish.railway.app`)
2. Wait for DNS to propagate
3. Visit `https://workwithnitish.dev` 🎉

## Common Issues

**"Website not loading"**
- Check DNS propagation: [whatsmydns.net](https://whatsmydns.net)
- Make sure you added both A and CNAME records

**"502 Bad Gateway"**
- App might be starting up (wait 30 seconds)
- Check logs in your hosting provider dashboard

**"SSL Certificate error"**
- Most providers auto-generate SSL (wait 10-15 minutes)
- Railway/Render: SSL is automatic
- Azure: Enable in SSL settings

## Need Help?

1. Check the full README.md for detailed instructions
2. Contact your hosting provider's support
3. Verify your domain registrar settings

Good luck! 🚀
