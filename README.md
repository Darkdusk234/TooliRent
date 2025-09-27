# TooliRent


# EndPoints
Auth
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
-/api/Auth: Allows registration of new member. Takes in registerDto to create a user and returns either 200 status code if it succeded or 400 status code with message of what went wrong.

-/api/Auth/login: Allows user to login to the system. Takes in LoginDto and checks if a user with that information exists. If correct returns 200 status code with jwt token for authorization. If something is incorrect returns 401 status code with message about if username or password is wrong, or if user is unactivated in system and to contact an admin if this is wrong.

-/api/Auth/{id}: Allows admins to deactivate accounts that aren't members anymore. Takes in id of user and returns 200 status code if user is found and gets deactivated. Returns 400 if user is already deactivated and returns 404 if user is not found. Returns a 401 status code if not logged in with a valid JWT token.

-/api/Auth/activate/{id}: Allows admins to activate accounts that are members again. Takes in id of user and returns 200 status code if user is found and gets activated. Returns 400 status code if user is already activated and returns 404 if user is not found. Returns a 401 status code if not logged in with a valid JWT token.
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


Tools
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Get End Points:
-/api/Tools: Allows users to see all tools in system. It requires no input from user other than calling on it and returns an 200 status code with a list of all tools shown in ToolDtos. Returns a 401 status code if not logged in with a valid JWT token.

-/api/Tools/{id}: Allows users to see a specific tool in the system. Takes in an int of the toolid and returns 200 status code with a toolDto of the specified tool or a 404 with message saying tool can't be found. Returns a 401 status code if not logged in with a valid JWT token.

-/api/Tools/isAvailable/{available}: Allows user to see all tools that are available or not available depending on input. Takes in a bool and returns a 200 status code with a list of tools that are available if input is true, or tools that aren't available if input is false. Returns a 401 status code if not logged in with a valid JWT token.

-/api/Tools/categoryId/{categoryId}: Allows user to see all tools belonging to a certain category. Takes in an int of the categoryId and returns a 200 status code with a list of tools belonging to that categoryId. Returns a 401 status code if not logged in with a valid JWT token.

Post End Points:
-/api/Tools: Allows admins to create a new tool for the system. Takes in an createToolDto and returns an 201 status code with a toolDto of the created tool. Returns 400 status code with message of what part is the problem. Returns a 401 status code if not logged in with a valid admin JWT token.

Put End Points:
-/api/Tools/{id}: Allows admins to update an existing tool in the system. Takes in an updateToolDto and returns 204 status code with nothing in it if tool was updated. Returns 400 status code with a message what of part is the problem, and returns a 404 status code if tool or category can't be found. Returns a 401 status code if not logged in with a valid admin JWT token.

Delete End Points:
-/api/Tools/{id}: Allows admins to delete a tool from the system. Takes in an int of the toolId and returns a 204 status code with nothing in it if tool was deleted. Returns a 404 status code if tool can't be found. Returns a 401 status code if not logged in with a valid JWT token.
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Categories
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Get End Points:
-/api/Categories: Allows users to see all categories in system. It requires no input from user other than calling on it and returns an 200 with a list of all categories shown in CategoryDtos. Returns a 401 status code if not logged in with a valid JWT token.

-/api/Categories/{id}: Allows users to see a specific category in the system. Takes in an int of the categoryid and returns 200 with a categoryDto of the specified category or a 404 status code with message saying category can't be found. Returns a 401 status code if not logged in with a valid JWT token.

Post End Points:
-/api/Categories: Allows admins to create a new category for the system. Takes in an createCategoryDto and returns an 201 status code with a categoryDto of the created category. Returns 400 status code with message of what part is the problem. Returns a 401 status code if not logged in with a valid admin JWT token.

Put End Points:
-/api/Categories/{id}: Allows admins to update an existing category in the system. Takes in an updateCategoryDto and returns 204 status code with nothing in it if category was updated. Returns 400 status code with a message of what part is the problem, and returns a 404 status code if category can't be found. Returns a 401 status code if not logged in with a valid admin JWT token.

Delete End Points:
-/api/Categories/{id}: Allows admins to delete a category from the system. Takes in an int of the categoryId and returns a 204 status code with nothing in it if category was deleted. Returns a 404 status code if category can't be found. Returns a 401 status code if not logged in with a valid JWT token.
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Bookings
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Get End Points:
-/api/Bookings: Allows a user to get all bookings in the system. It requires no input from user other than calling on it and returns a 200 status code with a list of all bookings shown in bookingDtos. Returns a 401 status code if not logged in with a valid JWT token.

-/api/Bookings/{id}: Allows a user to get a specific booking in the system. Takes in an int of the bookingId and returns 200 status code with a bookingDto of the specified booking, or it returns a 404 with a message saying booking can't be found. Returns a 401 status code if not logged in with a valid JWT token.

-/apit/Bookings/active: Allows a user to get all still active bookings in the system. It requires no input from user other than calling on it and returns a 200 status code with a list of bookings shown in bookingDtos. Returns a 401 status code if not logged in with a valid JWT token.

-/api/Bookings/pickup/{isPickedUp}: Allows a user to get all bookings that have or have not been picked up depending on input. Takes in a bool of if the booking has been picked up or not and returns a 200 status code with a list of bookings shown in bookingDtos that have or have not been picked up depending on input. Returns a 401 status code if not logged in with a valid JWT token.

-/api/Bookings/return/{isReturned}: Allows a user to get all bookings that have ir have not been returned depending on input. Takes in a bool of if the booking has been returned or not and returns a 200 status code with a list of bookings shown in bookingDtos that have or have not been returned depending on input. Returns a 401 status code if not logged in with a valid JWT token.

-/api/Bookings/tool/{toolId}: Allows a user to get all bookings made for a specified tool. Takes in an int of the toolId and returns a 200 status code with a list of all bookings made for the specified tool, shown in bookingDtos. Returns a 401 status code if not logged in with a valid JWT token.

-/api/Bookings/user/{userId}: Allows a user to get all bookings made by a specified user. Takes in an string of the userID and returns a 200 status cpde with a list of all bookings made by the specified user, shown in bookingDtos. Returns a 401 status code if not logged in with a valid JWT token.

-/api/Bookings/daterange: Allows a user to get all bookings active within inputted date range. Takes in two different DateTimes one for start date and one for end date and returns a 200 status code with a list of bookings that are active withing that range, shown in bookingDtos. Returns a 401 status code if not logged in with a valid JWT token.

-/api/Bookings/statistics: Allows admins to get statistics of the system and how many bookings have been made under inoutted date range. Takes in two different DateTimes one for start date and one for end date and returns a 200 status code with data over the system shown in AdminStatisticDto. Returns a 401 status code if not logged in with a valid JWT token.

-/api/Bookings/lateReturns: Allows admins to get all bookings that were returned late that havn't been handled yet. It takes no input expect being called on and returns a 200 status code with a list of late returned bookings shown in bookingDtos. Returns a 401 status code if not logged in with a valid JWT token.

Post End Points:
-/api/Bookings: Allows a user to create a new booking for the system. Takes in an createBookingDto and returns an 201 status code with a BookingDto of the created booking. Returns 400 status code with message of what part is the problem. Returns a 401 status code if not logged in with a valid admin JWT token.

Put End Points
-/api/Bookings/{id}: Allows a user to update an existing booking in the system. Takes in a updateBookingDto and returns 204 status code with nothing in it if booking was updated. Returns 400 statsu code with a message of what part is the problem and returns a 404 status code if booking can't be found or if updated booking has toolId or userId that can't be found. Returns a 401 status code if not logged in with a valid admin JWT token.

-/api/Bookings/cancel/{id}: Allows a user to cancel a booking. Takes in an int of the bookingId and returns 204 status code with nothing in it if booking was cancelled. Returns 404 status code if booking can't be found or is not active. Returns a 401 status code if not logged in with a valid admin JWT token.

-/api/Bookings/pickup/{id}: Allows admins to mark a booking as picked up. Takes in an int of the bookingId and returns 204 status code with nothing in it if booking was marked as picked up. Returns 404 status code if booking can't be found, is not active or if it already is marked as picked up. Returns a 401 status code if not logged in with a valid admin JWT token.

-/api/Bookings/return/{id}: Allows admins to mark a booking as returned. Takes in an int of the bookingId and returns 204 status code with nothing in it if booking was marked as returned. Returns 404 status code if booking can't be found, is not active or if it already is marked as returned. Returns a 401 status code if not logged in with a valid admin JWT token.

-/api/Bookings/lateReturneHandled/{id}: Allows admins to mark a late returned booking as handled. Takes in an int of the bookingId and returns 204 status code with nothing in it if booking was marked as handled. Returns 404 status code if booking can't be found, is not a late return or is already handled. Returns a 401 status code if not logged in with a valid admin JWT token.

Delete End Points
-/api/Bookings/{id}: Allows admins to delete a booking from the system. Takes in an int of the bookingId and returns a 204 status code with nothing in it if booking was deleted. Returns a 404 status code if booking can't be found. Returns a 401 status code if not logged in with a valid JWT token.
