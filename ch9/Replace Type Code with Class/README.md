# Problem
A field’s type (e.g., a String or int) fails to protect it from unsafe assignments and invalid equality comparisons.

# Refactoring Subject
Constrain the assignments and equality comparisons by making the type of the field a class.