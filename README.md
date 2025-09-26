# TooliRent


# EndPoints
Auth
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
-/api/Auth: Allows registration of new member. Takes in registerDto to create a user and returns either 200 code if it succeded or 400 error code with message of what went wrong.

-/api/Auth/login: Allows user to login to the system. Takes in LoginDto and checks if a user with that information exists. If correct returns 200 code with jwt token for authorization. If something is incorrect returns 401 code with message about if username or password is wrong, or if user is unactivated in system and to contact an admin if this is wrong.

-/api/Auth/{id}: Allows admins to deactivate accounts that aren't members anymore. Takes in id of user and returns ok if user is found and gets deactivated. Returns 400 if user is already deactivated and returns 404 if user is not found.

-/api/Auth/activate/{id}: Allows admins to activate accounts that are members again. Takes in id of user and returns ok if user is found and gets activated. Returns 400 if user is already activated and returns 404 if user is not found.
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


Tools
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Get End Points:
-/api/Tools: Allows users to see all tools in system. It requires no input from user other than calling on it and returns an 200 with a list of all tools shown in ToolDtos. Returns a 401 if not logged in with a valid JWT token.

-/api/Tools/{id}: Allows users to see a specifik tool in the system. Takes in an int of the toolid and returns 200 a toolDto of the specified tool or a 404 with message saying tool can't be found. Returns a 401 if not logged in with a valid JWT token.

-/api/Tools/isAvailable/{available}: Allows user to see all tools that are available or not available depending on input. Takes in a bool and returns a 200 with a list of tools that are available if input is true, or tools that aren't available if input is false. Returns a 401 if not logged in with a valid JWT token.

-/api/Tools/categoryId/{categoryId}: Allows user to see all tools belonging to a certain category. Takes in an int of the categoryId and returns a 200 with a list of tools belonging to that categoryId. Returns a 401 if not logged in with a valid JWT token.

Post End Points:
-/api/Tools: Allows admins to create a new tool for the system. Takes in an createToolDto and returns an 201 status code with a toolDto of the created tool. Returns 400 status code with message of what part is the problem. Returns a 401 if not logged in with a valid admin JWT token.

Put End Points:
-/api/Tools/{id}: Allows admins to update an existing tool in the system. Takes in an updateToolDto and returns 204 status code with nothing in it. Returns 400 status code with a message what part is the problem, and returns a 404 if tool or category can't be found. Returns a 401 if not logged in with a valid admin JWT token.

Delete End Points:
-/api/Tools/{id}: Allows admins to delete a tool from the system. Takes in an int of the toolId and returns a 204 status code with nothing in it. Returns a 404 if tool can't be found. Returns a 401 if not logged in with a valid JWT token.
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
