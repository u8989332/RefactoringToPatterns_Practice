# Problem
Two methods in subclasses perform similar steps in the same order, yet the steps are different.

# Refactoring Subject
Generalize the methods by extracting their steps into methods with identical signatures, then pull up the generalized methods to form a Template Method.