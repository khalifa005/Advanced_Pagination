# Advanced_Pagination

![.NET Core](https://github.com/khalifa005/Advanced_Pagination/workflows/.NET%20Core/badge.svg?branch=khalifa)
![.NET Core](https://github.com/khalifa005/Advanced_Pagination)
![.NET Core](https://github.com/silverkeytech/giz-labour-market-access/workflows/.NET%20Core/badge.svg?branch=dev)
Related documents:

* [Requirements]()
* [Specifications](https://docs.google.com/document/d/1Ki-qKeKIQ4sz3M3Eb7tzt0Z)

Test Sites:

* [Live Demo](http://lmap.demoday.us)
* [Why to use pagination]
# What is Paging? Why is it Important?

Imagine you have an endpoint in your API that could potentially return millions of records with a single request. Let’s say there are 100s of users that are going to exploit this endpoint by requesting all the data in a single go at the same time. This would nearly kill your server and lead to several issues including security.

An ideal API endpoint would allow it’s consumers to get only a specific number of records in one go. In this way, we are not giving load to our Database Server, the CPU on which the API is hosted, or the network bandwidth. This is a highly crucial feature for any API. especially the public APIs.

Paging or Pagination in a method in which you get paged response. This means that you request with a page number and page size, and the ASP.NET Core WebApi returns exactly what you asked for, nothing more.

-----------------------------------
# Getting Started with Pagination in ASP.NET Core WebApi
Wrappers for API Endpoints

It’s always a good practice to add wrappers to your API response. What is a wrapper? Instead of just returning the data in the response, you have a possibility to return other parameters like error messages, response status, page number, data, page size, and so on. You get the point. So, instead of just returning List<Customer>, we will return Response<List<Customer>>. This would give us more flexibility and data to work with, Right?
