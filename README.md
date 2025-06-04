# Portfolio CI/CD Project (.NET 8)

## 📌 Description  
This project demonstrates a CI/CD pipeline with automated tests using WebDriver and Cucumber in .NET 8.  
It includes deployment and monitoring with Azure, allowing seamless cloud-based execution.  

## ✅ Requirements  
- .NET 8+  
- Selenium WebDriver  
- SpecFlow (Cucumber for C#)  
- GitHub/GitLab CI/CD  
- Docker  
- Azure App Service  
- Azure Application Insights  

## 🚀 CI/CD Pipeline  
### GitHub Actions Workflow 
The project is automatically deployed to Azure App Service using GitHub Actions:  
```yaml
- name: Login to Azure
  uses: azure/login@v1
  with:
    creds: ${{ secrets.AZURE_CREDENTIALS }}

- name: Deploy to Azure
  uses: azure/webapps-deploy@v2
  with:
    app-name: portfolio-ci-cd-dotnet8
    publish-profile: ${{ secrets.AZURE_PUBLISH_PROFILE }}
    package: .
