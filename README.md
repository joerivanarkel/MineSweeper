[![.NET](https://github.com/vanarkel/MineSweeper/actions/workflows/dotnet.yml/badge.svg)](https://github.com/vanarkel/MineSweeper/actions/workflows/dotnet.yml)
[![Deploy to GitHub Pages](https://github.com/vanarkel/MineSweeper/actions/workflows/deploy.yml/badge.svg)](https://github.com/vanarkel/MineSweeper/actions/workflows/deploy.yml)

# MineSweeper

A classic MineSweeper game built with Blazor WebAssembly and C#.

## 🎮 Play Online

**[Play Now!](https://vanarkel.github.io/MineSweeper/)**

## 🚀 Deployment to GitHub Pages

This project is configured to automatically deploy to GitHub Pages using GitHub Actions.

### Setup Steps:

1. **Enable GitHub Pages in your repository:**
   - Go to your repository on GitHub
   - Navigate to **Settings** → **Pages**
   - Under **Source**, select **GitHub Actions**

2. **Push your code:**
   ```bash
   git add .
   git commit -m "Add Blazor WebAssembly with GitHub Pages deployment"
   git push origin master
   ```

3. **Wait for deployment:**
   - Go to the **Actions** tab in your repository
   - The deployment workflow will automatically run
   - Once complete, your app will be available at: `https://vanarkel.github.io/MineSweeper/`

### How it Works:

- The `.github/workflows/deploy.yml` workflow automatically builds and deploys the app when you push to the `master` branch
- The app is built using `dotnet publish`
- The base path is automatically updated to match your repository name
- A `.nojekyll` file is added to ensure proper routing
- A `404.html` file is created for SPA fallback routing

## 🛠️ Local Development

### Prerequisites:
- .NET 6.0 SDK or later

### Running Locally:

1. Clone the repository:
   ```bash
   git clone https://github.com/vanarkel/MineSweeper.git
   cd MineSweeper
   ```

2. Run the application:
   ```bash
   cd MineSweeperClient
   dotnet run
   ```

3. Open your browser and navigate to the URL shown in the terminal (typically `https://localhost:5001` or `http://localhost:5000`)

### Building for Production:

```bash
cd MineSweeperClient
dotnet publish -c Release
```

The published files will be in `bin/Release/net6.0/publish/wwwroot/`

## 📁 Project Structure

- **MineSweeperClient/** - Blazor WebAssembly client application
- **MineSweeperLogic/** - Game logic library
- **MineSweeperClientBlazor/** - Legacy Blazor Server version (deprecated)

## 🎯 Features

- Classic MineSweeper gameplay
- Left-click to reveal cells
- Right-click to flag mines
- Middle-click for chord reveal
- Timer and move counter
- Win/loss detection
- Game logging

## 📝 Notes

- The app uses client-side rendering (Blazor WebAssembly)
- All game logic runs in the browser
- No server-side dependencies required for deployment
- Compatible with GitHub Pages static hosting

## 🤝 Contributing

Feel free to submit issues and pull requests!
