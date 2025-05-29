SELECT i.IngredientName,
	   ri.Quantity,
	   ri.Units	
FROM RecipeIngredients ri
JOIN Ingredients i ON ri.IngredientID = i.IngredientID
WHERE ri.RecipeID = @RecipeID
