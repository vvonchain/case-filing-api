# Swagger UI Documentation

The Eviction Case Filing API provides a Swagger UI for exploring and testing the API endpoints. The Swagger UI allows you to view the available operations, request/response models, and even make sample requests directly from the browser.

## Accessing Swagger UI

To access the Swagger UI, follow these steps:

1. Run the Eviction Case Filing API project.
2. Open a web browser and navigate to `https://localhost:<port>/swagger`, where `<port>` is the port number your API is running on (e.g., `https://localhost:5001/swagger`).

## Using Swagger UI

Once you have accessed the Swagger UI, you will see a list of available API endpoints and their associated HTTP methods.

To explore an endpoint:

1. Click on the endpoint to expand its details.
2. You will see the request parameters, request body (if applicable), and the expected response.
3. Click on the "Try it out" button to make a sample request to the endpoint.
4. Fill in any required parameters or request body.
5. Click the "Execute" button to send the request.
6. The response will be displayed below, including the response code, headers, and body.

## Generating OpenAPI Definition

You can also generate the OpenAPI definition file for the API using Swagger UI.

To generate the OpenAPI definition:

1. Access the Swagger UI as described above.
2. Click on the "Download" button at the top of the page.
3. Select either "Download as OpenAPI 3.0" or "Download as Swagger" to download the OpenAPI definition file in the desired format.

Alternatively, you can access the OpenAPI definition file directly at `https://localhost:<port>/swagger/v1/swagger.json`.

The generated OpenAPI definition file can be used to import the API into other tools or documentation systems that support OpenAPI.