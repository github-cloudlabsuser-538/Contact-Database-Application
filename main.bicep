param webAppName string
param location string = resourceGroup().location

resource appServicePlan 'Microsoft.Web/serverfarms@2021-01-01' = {
  name: '${webAppName}ServicePlan'
  location: location
}

resource webApp 'Microsoft.Web/sites@2021-01-01' = {
  name: webAppName
  location: location
  properties: {
    serverFarmId: appServicePlan.id
  }
}
