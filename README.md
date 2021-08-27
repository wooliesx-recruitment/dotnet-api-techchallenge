## Welcome!

This repository contains a solution to a tech challenge described in the below section.  

## Problem domain 

This is designed to demonstrate practical skills around building and hosting Web APIs. 

There are multiple endpoints in the API which solves different challenges. 

* User endpoint - This endpoint will return a JSON object in the format 
```
{
  "name": "test", 
  "token" : "1234-455662-22433333-3333"
}
```
* Sort endpoint - This endpoint will need to accept a query string parameter called "sortOption" which will take in the following strings : 
  - "Low" - Low to High Price
  - "High" - High to Low Price
  - Ascending" - A - Z sort on the Name
  - Descending" - Z - A sort on the Name
  - Recommended" - this will call the "shopperHistory" resource to get a list of customers orders and needs to return based on popularity,

It needs to call the "products" resource to get a list of available products. 
Response will be in the same data structure as the "products" response (only sorted correctly). 

## What we expect from you 

* You are not required to produce any code yourself or make modifications to the shared code. 
* You will however need to spend a **maximum of 30 mins** to familiarise yourself with the code before attending the first interview. 
* The code will be used as a reference in our technical interview. 
* The technical interview will not be limited to the code shared.
