# Gilded Rose Refactoring Kata

<details>
<summary>How to use this Kata</summary>

The first thing to do is make a copy of this repository in your personal GitHub account and make public. Please do not fork this repository as your solution will be visible to others undertaking this exercise.

The purpose of this exercise is to demonstrate your skills at designing test cases and refactoring a legacy codebase, safely. 

The idea is not to re-write the code from scratch, but rather to practice taking small steps, running the tests often, and incrementally improve the design towards a solution that embodies OO principles and patterns.
</details>
<details>
<summary>Gilded Rose Requirements Specification</summary>

Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a
prominent city ran by a friendly innkeeper named Allison. We also buy and sell only the finest goods.
Unfortunately, our goods are constantly degrading in `Quality` as they approach their sell by date.

We have a system in place that updates our inventory for us. It was developed by a no-nonsense type named
Leeroy, who has moved on to new adventures. Your task is to add the new feature to our system so that
we can begin selling a new category of items. First an introduction to our system:

- All `items` have a `SellIn` value which denotes the number of days we have to sell the `items`
- All `items` have a `Quality` value which denotes how valuable the item is
- At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

- Once the sell by date has passed, `Quality` degrades twice as fast
- The `Quality` of an item is never negative
- __"Aged Brie"__ actually increases in `Quality` the older it gets
- The `Quality` of an item is never more than `50`
- __"Sulfuras"__, being a legendary item, never has to be sold or decreases in `Quality`
- __"Backstage passes"__, like aged brie, increases in `Quality` as its `SellIn` value approaches;
	- `Quality` increases by `2` when there are `10` days or less and by `3` when there are `5` days or less but
	- `Quality` drops to `0` after the concert

We have recently signed a supplier of conjured items. This requires an update to our system:

- __"Conjured"__ items degrade in `Quality` twice as fast as normal items

Feel free to make any changes to the `UpdateQuality` method and add any new code as long as everything
still works correctly. However, do not alter the `Item` class or `Items` property as those belong to the
goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code
ownership (you can make the `UpdateQuality` method and `Items` property static if you like, we'll cover
for you).

Just for clarification, an item can never have its `Quality` increase above `50`, however __"Sulfuras"__ is a
legendary item and as such its `Quality` is `80` and it never alters.
</details>
<details>
<summary>Introduction to Text-Based Approval Testing</summary>
This is a testing approach which is very useful when refactoring legacy code. Before you change the code, you run it, and gather the output of the code as a plain text file. You review the text, and if it correctly describes the behaviour as you understand it, you can "approve" it, and save it as a "Golden Master". Then after you change the code, you run it again, and compare the new output against the Golden Master. Any differences, and the test fails.

It's basically the same idea as "assertEquals(expected, actual)" in a unit test, except the text you are comparing is typically much longer, and the "expected" value is saved from actual output, rather than being defined in advance.

Typically a piece of legacy code may not produce suitable textual output from the start, so you may need to modify it before you can write your first text-based approval test. This has already been setup and the initial "Golden Master" has been provided in `ApprovalTest.ThirtyDays.verified.txt`
</details>

## Branches

### [main](https://github.com/steve-codemunkies/GildedRose)

Main branch - contains refactoring and implementation of Conjured Items.

### [sh/paused-refactor](https://github.com/steve-codemunkies/GildedRose/tree/sh/paused-refactor)

Initial refactor, paused as it occurred to me that it might be better/easier to restart but refactor out the min and max quality tests.

### [sh/unexpected-bspass-problem](https://github.com/steve-codemunkies/GildedRose/tree/sh/unexpected-bspass-problem)

During the work on [`sh/paused-refactor`](https://github.com/steve-codemunkies/GildedRose/tree/sh/paused-refactor) I encountered an issue with the output for Backstage Passes. I moved the change on to it's own branch, and restarted trying to simplify the `QualityUpdate` method.

### [sh/attempt-to-move-sellin-decrease](https://github.com/steve-codemunkies/GildedRose/tree/sh/attempt-to-move-sellin-decrease)

Based on [`main`](https://github.com/steve-codemunkies/GildedRose) I again (see [`sh/unexpected-bspass-problem`](https://github.com/steve-codemunkies/GildedRose/tree/sh/unexpected-bspass-problem)) encountered the same issue with Backstage Passes. This time I felt the code was in a better shape to switch to unit testing. The code change that cause this reorientation is parked here.

### [sh/unconstrained-refactor](https://github.com/steve-codemunkies/GildedRose/tree/sh/unconstrained-refactor)

Following on from [`main`](https://github.com/steve-codemunkies/GildedRose) this ignores the following:

> However, do not alter the `Item` class or `Items` property as those belong to the goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code ownership

All logic is broken out to individual Single Responsibility classes.

The program is largely unaltered (beyond the use of factory functions) and is responsible for formatting the output.