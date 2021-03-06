﻿using System;
using System.Collections.Generic;

namespace myglm
{
    public class Vec5
    {
        public float x = 0;
        public float y = 0;
        public float z = 0;
        public float w = 0;
        public float v = 0;
        public float Length { get => Length_aux(); }

        private float Length_aux()
        {
            Vec5 vec_remon = RenormalizeByv(this);
            return (float)Math.Sqrt(vec_remon.x * vec_remon.x + vec_remon.y * vec_remon.y + vec_remon.z * vec_remon.z + vec_remon.w * vec_remon.w);
        }
        public Vec5(float _x = 0, float _y = 0, float _z = 0, float _w = 0, float _v = 1)
        {
            x = _x; y = _y; z = _z; w = _w; v = _v;
        }
        public float this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    case 3: return w;
                    case 4: return v;
                    default: throw new System.AccessViolationException();
                }
            }
            set
            {
                switch (i)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    case 3: w = value; break;
                    case 4: v = value; break;
                    default: throw new System.AccessViolationException();
                }
            }
        }

        public static Vec5 Normalize(Vec5 vec)
        {
            Vec5 vec3 = new Vec5();
            if (vec.Length == 0)
                return vec;
            for (int i = 0; i < 4; i++)
            {
                vec3[i] = vec[i] / vec.Length;
            }
            if (vec[4] == 0)
                vec3[4] = 0;
            else
                vec3[4] = 1;
            return vec3;
        }
        public Vec5 Normalize()
        {
            return Normalize(this);
        }
        private static Vec5 RenormalizeByv(Vec5 vec)
        {
            float pivot = vec[4];
            if (pivot == 0)
                return vec;
            else
            {
                Vec5 vec3 = new Vec5();
                for (int i = 0; i < 4; i++)
                {
                    vec3[i] = vec[i] / pivot;
                }
                vec3[4] = 1;
                return vec3;
            }
        }
        public static float DotProduct(Vec5 vec1, Vec5 vec2)
        {
            float t = 0.0f;
            Vec5 vec1_renom = RenormalizeByv(vec1);
            Vec5 vec2_renom = RenormalizeByv(vec2);
            for (int i = 0; i < 4; i++)
            {
                t += vec1_renom[i] * vec2_renom[i];
            }
            return t;
        }
        public float DotProduct(Vec5 vec1)
        {
            float t = 0.0f;
            Vec5 vec1_renom = RenormalizeByv(this);
            Vec5 vec2_renom = RenormalizeByv(vec1);
            for (int i = 0; i < 4; i++)
            {
                t += vec1_renom[i] * vec2_renom[i];
            }
            return t;
        }
        public static Vec5 CorssProduct(Vec5 _vec1, Vec5 _vec2, Vec5 _vec3)
        {
            Vec5 vec4 = new Vec5();
            Vec5 vec1 = RenormalizeByv(_vec1);
            Vec5 vec2 = RenormalizeByv(_vec2);
            Vec5 vec3 = RenormalizeByv(_vec3);
            vec4.x = vec1.y * (vec2.z * vec3.w - vec2.w * vec3.z) + vec1.z * (vec2.w * vec3.y - vec2.y * vec3.w) + vec1.w * (vec2.y * vec3.z - vec2.z * vec3.y);
            vec4.y = vec1.z * (vec2.w * vec3.x - vec2.x * vec3.w) + vec1.w * (vec2.x * vec3.z - vec2.z * vec3.x) + vec1.x * (vec2.z * vec3.w - vec2.w * vec3.z);
            vec4.z = vec1.w * (vec2.x * vec3.y - vec2.y * vec3.x) + vec1.x * (vec2.y * vec3.w - vec2.w * vec3.y) + vec1.y * (vec2.w * vec3.x - vec2.x * vec3.w);
            vec4.w = vec1.x * (vec2.y * vec3.z - vec2.z * vec3.y) + vec1.y * (vec2.z * vec3.x - vec2.x * vec3.z) + vec1.z * (vec2.x * vec3.y - vec2.y * vec3.x);
            if (vec1[4] == vec2[4] && vec2[4] == vec3[4] && vec3[4] == 0)
                vec4.v = 0;
            else if (vec1[4] == vec2[4] && vec2[4] == vec3[4] && vec3[4] == 1)
                vec4.v = 1;
            else
            {
                throw new System.ArgumentException();
            }
            return vec4;
        }
        public static Vec5 operator +(Vec5 vec1, Vec5 vec2)
        {
            Vec5 vec3 = new Vec5();
            Vec5 vec1_renom = RenormalizeByv(vec1);
            Vec5 vec2_renom = RenormalizeByv(vec2);
            for (int i = 0; i < 4; i++)
            {
                vec3[i] = vec1_renom[i] + vec2_renom[i];
            }
            if (vec1_renom[4] == 0 && vec2_renom[4] == 0)
                vec3[4] = 0;
            else if (vec1_renom[4] == 1 && vec2_renom[4] == 1)
                vec3[4] = 1;
            else
            {
                throw new System.ArgumentException();
            }
            return vec3;
        }
        public static Vec5 operator -(Vec5 vec1, Vec5 vec2)
        {
            Vec5 vec3 = new Vec5();
            Vec5 vec1_renom = RenormalizeByv(vec1);
            Vec5 vec2_renom = RenormalizeByv(vec2);
            for (int i = 0; i < 4; i++)
            {
                vec3[i] = vec1_renom[i] - vec2_renom[i];
            }
            if (vec1_renom[4] == 0 && vec2_renom[4] == 0)
                vec3[4] = 0;
            else if (vec1_renom[4] == 1 && vec2_renom[4] == 1)
                vec3[4] = 1;
            else
            {
                throw new System.ArgumentException();
            }
            return vec3;
        }
        public static Vec5 operator -(Vec5 vec)
        {
            Vec5 vec3 = new Vec5();
            for (int i = 0; i < 5; i++)
            {
                vec3[i] = -vec[i];
            }
            vec3[4] = vec[4];
            return vec3;
        }
        public static Vec5 operator *(float c, Vec5 vec)
        {
            Vec5 vec3 = new Vec5();
            for (int i = 0; i < 4; i++)
            {
                vec3[i] = c * vec[i];
            }
            vec3[4] = vec[4];
            return vec3;
        }
        public static Vec5 operator *(Vec5 vec, float c)
        {
            Vec5 vec3 = new Vec5();
            for (int i = 0; i < 5; i++)
            {
                vec3[i] = c * vec[i];
            }
            vec3[4] = vec[4];
            return vec3;
        }
    }
    public class Mat5
    {
        private float[,] mat;
        public float this[int i, int j]
        {
            get
            {
                return mat[i, j];
            }
            set
            {
                mat[i, j] = value;
            }
        }
        public float Determinant { get => Determinant_aux(mat, 5); }

        private float Determinant_aux(float[,] mat_aux, int n)
        {
            Mat5 origin = new Mat5(mat);
            Mat5 mat3 = new Mat5();
            for (int i = 0; i < 5; i++)
            {
                if (origin[i, i] == 0.0f)
                {
                    int j = 0;
                    for (j = i + 1; j < 5; j++)
                    {
                        if (origin[j, i] != 0.0f)
                            RowChange(i, j, origin);
                    }
                    if (j == 5)
                        return 0;
                }
                for (int j = i + 1; j < 5; j++)
                {
                    float pivot = (origin[j, i] / origin[i, i]);
                    for (int k = i; k < 5; k++)
                    {
                        origin[j, k] -= pivot * origin[i, k];
                        mat3[j, k] -= pivot * mat3[i, k];
                    }
                    origin[j, i] = 0.0f;
                }
            }
            float t = 1;
            for (int i = 0; i < 5; i++)
            {
                t *= mat3[i, i];
            }
            return t;
        }
        public Mat5(float scale = 1.0f)
        {
            mat = new float[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == j)
                    {
                        if (i == 5)
                            mat[i, j] = 1;
                        else
                            mat[i, j] = scale;
                    }
                    else
                    {
                        mat[i, j] = 0;
                    }
                }
            }
        }
        public Mat5(Mat5 _mat)
        {
            mat = new float[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mat[i, j] = _mat[i, j];
                }
            }
        }
        public Mat5(float[,] _mat)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mat[i, j] = _mat[i, j];
                }
            }
        }
        public static Mat5 operator +(Mat5 mat1, Mat5 mat2)
        {
            Mat5 mat3 = new Mat5();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mat3[i, j] = mat1[i, j] + mat2[i, j];
                }
            }
            return mat3;
        }
        public static Mat5 operator -(Mat5 mat1, Mat5 mat2)
        {
            Mat5 mat3 = new Mat5();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mat3[i, j] = mat1[i, j] - mat2[i, j];
                }
            }
            return mat3;
        }
        public static Mat5 operator -(Mat5 mat)
        {
            Mat5 mat3 = new Mat5();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mat3[i, j] = -mat[i, j];
                }
            }
            return mat3;
        }
        public Mat5 Transpose()
        {
            Mat5 mat3 = new Mat5();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mat3[i, j] = mat[j, i];
                }
            }
            return mat3;
        }
        public static Mat5 Transpose(Mat5 mat)
        {
            Mat5 mat3 = new Mat5();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mat3[i, j] = mat[j, i];
                }
            }
            return mat3;
        }
        private static void RowChange(int i, int j, in Mat5 _mat)
        {
            float temp;
            for (int k = 0; k < 5; i++)
            {
                temp = _mat[i, k];
                _mat[i, k] = _mat[j, k];
                _mat[j, k] = temp;
            }
        }

        public Mat5 Inverse()
        {
            Mat5 origin = new Mat5(mat);
            Mat5 mat3 = new Mat5();
            for (int i = 0; i < 5; i++)
            {
                if (origin[i, i] == 0.0f)
                {
                    int j = 0;
                    for (j = i + 1; j < 5; j++)
                    {
                        if (origin[j, i] != 0.0f)
                            RowChange(i, j, origin);
                    }
                    if (j == 5)
                        throw new System.DivideByZeroException();
                }
                for (int j = i + 1; j < 5; j++)
                {
                    float pivot = (origin[j, i] / origin[i, i]);
                    for (int k = i; k < 5; k++)
                    {
                        origin[j, k] -= pivot * origin[i, k];
                        mat3[j, k] -= pivot * mat3[i, k];
                    }
                    origin[j, i] = 0.0f;
                }
            }
            for (int i = 4; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    float pivot = (origin[j, i] / origin[i, i]);
                    for (int k = 0; k < 5; k++)
                    {
                        mat3[j, k] -= pivot * mat3[i, k];
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                float pivot = origin[i, i];
                for (int j = 0; j < 5; j++)
                {
                    mat3[i, j] /= pivot;
                }
            }
            return mat3;
        }
        public static Mat5 Inverse(Mat5 mat)
        {
            Mat5 origin = new Mat5(mat);//mat
            Mat5 mat3 = new Mat5();//identity
            for (int i = 0; i < 5; i++)
            {
                if (origin[i, i] == 0.0f)
                {
                    int j = 0;
                    for (j = i + 1; j < 5; j++)
                    {
                        if (origin[j, i] != 0.0f)
                            RowChange(i, j, origin);
                    }
                    if (j == 5)
                        throw new System.DivideByZeroException();
                }
                for (int j = i + 1; j < 5; j++)
                {
                    float pivot = (origin[j, i] / origin[i, i]);
                    for (int k = i; k < 5; k++)
                    {
                        origin[j, k] -= pivot * origin[i, k];
                        mat[j, k] -= pivot * mat[i, k];
                    }
                    origin[j, i] = 0.0f;
                }
            }
            for (int i = 4; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    float pivot = (origin[j, i] / origin[i, i]);
                    for (int k = 0; k < 5; k++)
                    {
                        mat[j, k] -= pivot * mat[i, k];
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                float pivot = origin[i, i];
                for (int j = 0; j < 5; j++)
                {
                    mat3[i, j] /= pivot;
                }
            }
            return mat3;
        }
        public static Vec5 operator *(Mat5 mat, Vec5 vec)
        {
            Vec5 temp = new Vec5();
            for (int i = 0; i < 5; i++)
            {
                float t = 0.0f;
                for (int j = 0; j < 5; j++)
                {
                    t += mat[i, j] * vec[j];
                }
                temp[i] = t;
            }
            return temp;
        }
        public static Mat5 operator *(Mat5 mat1, Mat5 mat2)
        {
            Mat5 temp = new Mat5();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    float t = 0.0f;
                    for (int k = 0; k < 5; k++)
                        t += mat1[i, k] * mat2[k, j];
                    temp[i, j] = t;
                }
            }
            return temp;
        }
    }
}