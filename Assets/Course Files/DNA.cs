using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DNA // No need spesific unity classes for this script.
{
    List<int> genes = new();
    int dnaLength; // Num of genes in dna.
    int maxValues; // Num of different values a gene can get.

    public int GetGene(int pos)
    {
        return genes[pos];
    }


    // Constructor
    public DNA(int l, int v)
    {
        dnaLength = l; // for now it only holds one dna.
        maxValues = v;
        SetRandom();
    }

    // Randomize genes.
    public void SetRandom()
    {
        genes.Clear();
        for (int i = 0; i < dnaLength; i++)
        {
            genes.Add(Random.Range(0, maxValues));
        }
    }

    // Change spesific gene of dna.
    public void SetInt(int pos, int value)
    {
        genes[pos] = value;
    }

    // Give Parent genes to offspring half by half
    public void Combine(DNA d1, DNA d2)
    {
        // Parent1   = a,b,c,d,e,f
        // Parent2   = g,h,i,j,k,l
        // Offspring = a,b,c,j,k,l or g,h,i,d,e,f
        for (int i = 0; i < dnaLength; i++)
        {
            if (i < dnaLength / 2)
            {
                int c = d1.genes[i];
                genes[i] = c;
            }
            else
            {
                int c = d2.genes[i];
                genes[i] = c;
            }
        }
    }

    // Set random value in a random gene.
    public void Mutate()
    {
        genes[Random.Range(0, dnaLength)] = Random.Range(0, maxValues);
    }
}