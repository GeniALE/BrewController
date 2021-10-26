module.exports = {
  parser: '@typescript-eslint/parser',
  plugins: [
    'svelte3',
    '@typescript-eslint',
  ],
  ignorePatterns: [
    '.eslintrc.js',
    'rollup.config.js',
    'svelte.config.js',
  ],
  parserOptions: {
    tsconfigRootDir: __dirname,
    project: ['./tsconfig.json'],
    extraFileExtensions: ['.svelte'],
  },
  extends: [
    'eslint:recommended',
    'plugin:@typescript-eslint/recommended',
    'plugin:@typescript-eslint/recommended-requiring-type-checking',
  ],
  overrides: [
    {
      files: ['*.svelte'],
      processor: 'svelte3/svelte3',
    },
  ],
  rules: {
    'no-undef': 'off',
    'semi': 'off',
    'quotes': 'off',
    'comma-dangle': 'off',
    'no-unused-vars': 'off',
    'eol-last': ['error', 'always'],
    'arrow-parens': ['error', 'always'],
    'no-tabs': 'error',
    'no-mixed-spaces-and-tabs': 'error',
    'indent': 'off',
    '@typescript-eslint/no-unsafe-call': 'off',
    '@typescript-eslint/no-unsafe-return': 'off',
    '@typescript-eslint/no-unsafe-argument': 'off',
    '@typescript-eslint/indent': [
      'error',
      2,
      {
        SwitchCase: 1,
      },
    ],
    '@typescript-eslint/no-unsafe-assignment': 0,
    '@typescript-eslint/no-unused-vars': 0,
    '@typescript-eslint/comma-dangle': ['error', 'always-multiline'],
    '@typescript-eslint/quotes': ['error', 'single'],
    '@typescript-eslint/no-use-before-define': 0,
    '@typescript-eslint/no-unsafe-member-access': 0,
    '@typescript-eslint/restrict-template-expressions': 0,
    '@typescript-eslint/member-delimiter-style': [
      'error',
      {
        multiline: {
          delimiter: 'none',
        },
      },
    ],
    '@typescript-eslint/semi': [
      'error',
      'never',
    ],
    'id-length': [
      'error',
      {
        min: 2,
        exceptions: ['i', '_', 'x', 'y'],
      },
    ],
  },
  settings: {
    'svelte3/typescript': () => require('typescript'),
    'svelte3/ignore-styles': () => true,
  }
};
