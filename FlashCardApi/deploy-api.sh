#!/bin/bash

echo "🔧 Publishing .NET project..."
dotnet publish -c Release

echo "📦 Zipping published files..."
zip -r flashcard-api.zip ./bin/Release/net9.0/publish > /dev/null

echo "🚀 Deploying to Azure..."
az webapp deployment source config-zip \
  --resource-group flashcard-ui_group \
  --name flashcard-api-demo \
  --src "$(pwd)/flashcard-api.zip"

echo "✅ Deployment complete!"
