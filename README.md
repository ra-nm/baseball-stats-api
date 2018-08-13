# Baseball Stats Sample Web Application API

This API for the Baseball Stats Sample Web Application runs on Azure Functions and queries baseball player salary data located in an Azure Table.

The API contains one endpoint:
```
GET /api/salaries
```

The following Query String Parameters are required on this endpoint:

|Parameter Name|Type|Description|
|---|---|---|
|code|string|A string provided by the Azure Function that allows access to the API.|
|teamId|string|The ID of the team that should be retrieved from the database.|
|yearId|int|The Year that should be retrieved from the database.|