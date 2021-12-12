# Temperature Project

## How to run the project

### Prerequisites

Needed tools:
* Visual Studio (projekt tworzony na Visual Studio 2017)
* Microsoft SQL Management Studio

### Running the project

1. Run Microsoft SQL Management Studio.
2. Save the local server name.
3. Run Visual Studio project (solution file is located here: [TemperatureProject.Api](https://github.com/bartlomiejobuchiewicz/TemperatureProject-OIRPOS-PAI/tree/master/TemperatureProject.Api)
4. Replace server name in appseting.json.

![connection_string](https://user-images.githubusercontent.com/54101971/145726328-43caafb2-fde1-4eb3-9eb0-04556e26032e.gif)

5. Launch the project.

A local database with a sample table is created automatically. After launching the application, the interface provided by the Swagger tool appears, presenting documentation of the created API and allowing to test particular entpoins.

## Instructions for the developer

Instructions can be found in the catalog: [dev_doc](https://github.com/bartlomiejobuchiewicz/TemperatureProject-OIRPOS-PAI/tree/master/dev_doc)

## User Manual

All endpoints can be tested using the Swagger API after the project is launched.

### GET /api​/v1​/originData​/all

This endpoint returns all measurements, according to provided filters from local database.

#### How to run this endpoint?

To run this endpoint you have to send a GET request to the server: https://server_url/api/v1/originData/all

#### What response is get?

The server returns all records from the Database, in the JSON format.


### GET /api​/v1​/originData​/{id}

This endpoint returns single measurement by id from local database.

#### How to run this endpoint?

To run this endpoint you have to send a GET request to the server: https://server_url/api/v1/originData/{id}. Where the id is obligatory request parameter and specifes identification number of desired record.

#### What response is get?

The server returns the record from the Database. The record which was specifed by the id. Data is delivered in the JSON format.

### DELETE /api​/v1​/originData​/{id}

This endpoint deletes single measurement with provided id from local database.

#### How to run this endpoint?

To run this endpoint you have to send a DELETE request to the server: https://server_url/api/v1/originData/{id}. Where the id is obligatory request parameter and specifes identification number of the record which is about to be removed.

#### What response is get?

The server returns inforamtion whether the deletion operation was succesfull or not.

### PATCH /api​/v1​/originData

This endpoint edits single measurement value with provided body.

#### How to run this endpoint?

To run this endpoint you have to send a PATCH request to the server: https://server_url/api/v1/originData. The selection of the patched record is determined by its id.

#### What response is get?

The server returns inforamtion whether the PATCH operation was succesfull or not.

### POST /api​/v1​/originData

This endpoint adds to database single measurement with provided body.

#### How to run this endpoint?

To run this endpoint you have to send a POST request to the server: https://server_url/api/v1/originData.

#### What response is get?

The server returns inforamtion whether the POST operation was succesfull or not.
