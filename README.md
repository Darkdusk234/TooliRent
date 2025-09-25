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
-GetAllTools
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
