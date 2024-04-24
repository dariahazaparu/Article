I covered all functionalities for the api
1. GET /api/articles: Retrieves a list of all articles.
2. GET /api/articles/{id}: Retrieves a single article by its ID. - not used in front end
2. GET /api/articles/GetByTitle/{title}: Retrieves a single article by its title. - not used in front end
3. POST /api/articles: Creates a new article.
4. PUT /api/articles/{id}: Updates an existing article by its ID.
5. DELETE /api/articles/{id}: Deletes an article by its ID.

Addition:
- included pagination on the get endpoint for articles - not available in front end
- included validation logic for create and update on an article.
- used dependency injection for services.

Article.Service.API -> contains the direct access to data features (as a microservice)
Article.Web -> simple front end design to illustrate the endpoints from API
