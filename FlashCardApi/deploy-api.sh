#!/bin/bash

echo "🛀 Cleaning .NET project..."
dotnet clean

echo "🔧 Publishing .NET project..."
dotnet publish -c Release

echo "📦 Zipping published files..."
cd ./bin/Release/net9.0/publish
zip -r ../../../../../flashcard-api.zip ./*
cd ../../../../../

echo "🚀 Deploying to Azure..."
az webapp deployment source config-zip \
  --resource-group flashcard-ui_group \
  --name flashcard-api-demo \
  --src "$(pwd)/flashcard-api.zip"

echo "✅ Deployment complete!"
