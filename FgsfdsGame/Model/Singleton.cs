using System;
using System.Reflection;

namespace FgsfdsGame.Model
{
    /// generic Singleton<T> (���������������� � �������������� generic-������ � � ���������� ��������������)

    /// <typeparam name="T">Singleton class</typeparam>
    public class Singleton<T> where T : class
    {
        /// ���������� ����������� ��������� ��� ����, ����� ������������� �������� ���������� ������ Singleton. 
        /// �� ����� ������ �� ��������� ������������ ��������������� ������.
        protected Singleton() { }

        /// ������� ������������ ��� ���������� ������������� ���������� ������
        private sealed class SingletonCreator<S> where S : class
        {
            //������������ Reflection ��� �������� ���������� ������ ��� ���������� ������������
            private static readonly S instance = (S)typeof(S).GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new Type[0],
                new ParameterModifier[0]).Invoke(null);

            public static S CreatorInstance
            {
                get { return instance; }
            }
        }

        public static T Instance
        {
            get { return SingletonCreator<T>.CreatorInstance; }
        }

    }
}