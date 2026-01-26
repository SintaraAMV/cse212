public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
    // PLAN (step-by-step):
    // 1) Create a double array with size = length.
    // 2) Loop i from 0 to length - 1.
    // 3) Store number * (i + 1) at index i (first multiple is number * 1).
    // 4) Return the array.

    double[] result = new double[length];

    for (int i = 0; i < length; i++)
    {
        result[i] = number * (i + 1);
    }

    return result;
}

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
   {
    // PLAN (step-by-step):
    // 1) Let n = data.Count.
    // 2) Normalize amount: amount = amount % n (if amount == n, it becomes 0).
    // 3) If amount == 0, do nothing and return.
    // 4) Compute split = n - amount (cut point).
    // 5) Copy the tail (last 'amount' elements) using GetRange.
    // 6) Remove that tail from the original list using RemoveRange.
    // 7) Insert the tail at the front using InsertRange.

    int n = data.Count;
    if (n == 0) return;

    amount = amount % n;
    if (amount == 0) return;

    int split = n - amount;

    List<int> tail = data.GetRange(split, amount);
    data.RemoveRange(split, amount);
    data.InsertRange(0, tail);
}
}
