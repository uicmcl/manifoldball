/// <summary>
/// Borromean rings 2-fold branched cover
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoroTiling: Tiling {
	private int N;
	private float cubesize;
	private Matrix4x4 origin;
	private Matrix4x4 inverseOrigin;

	public BoroTiling(Matrix4x4 origin, int N, float cubesize)
	{
		this.N = N;
		this.cubesize = cubesize;
		this.origin = origin;
		this.inverseOrigin = origin.inverse;
	}
		
	public override System.Collections.IEnumerator GetEnumerator()
	{
		for (int i = -N; i <= N; i++)
			for (int j = -N; j <= N; j++)
				for (int k = -N; k <= N; k++) {
					Matrix4x4 M = new Matrix4x4 ();
					M.SetRow (0, new Vector4 (eps(j+k),0,0,cubesize*i));
					M.SetRow (1, new Vector4 (0,eps(i+k),0,cubesize*j));
					M.SetRow (2, new Vector4 (0,0,eps(i+j),cubesize*k));
					M.SetRow (3, new Vector4 (0,0,0,1));	
					yield return origin*M*inverseOrigin;
				}
	}

	public override Matrix4x4 TileContaining(Matrix4x4 P)
	{
		return Matrix4x4.identity;
 	}

	private static int eps(int n)
	{
		return 1 - 2*(Math.Abs(n) % 2);
	}
}